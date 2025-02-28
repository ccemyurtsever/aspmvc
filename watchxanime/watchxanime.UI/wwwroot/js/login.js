document.addEventListener('DOMContentLoaded', function() {
    console.log('Login.js yüklendi');
    const loginForm = document.querySelector('form[action="/login"]');
    
    if (loginForm) {
        console.log('Login formu bulundu');
        loginForm.addEventListener('submit', async function(e) {
            e.preventDefault();
            console.log('Login formu gönderiliyor...');

            try {
                const formData = new FormData(this);
                const userData = {
                    UserName: formData.get('UserName'),
                    Password: formData.get('Password')
                };
                console.log('Gönderilen veri:', userData);

                const response = await fetch('/api/Users/login', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(userData)
                });

                const result = await response.json();
                console.log('Login yanıtı:', result);

                if (result.token) {
                    // JWT token'ı cookie'ye kaydet
                    document.cookie = `jwt_token=${result.token}; path=/; secure; samesite=strict`;
                    // User info'yu cookie'ye kaydet
                    const userInfo = {
                        userName: userData.UserName,
                        email: userData.UserName // API'den email dönmediği için username'i kullanıyoruz
                    };
                    document.cookie = `user_info=${JSON.stringify(userInfo)}; path=/; secure; samesite=strict`;
                    
                    showNotification('success', 'Giriş başarılı');
                    closeModal('loginModal');
                    window.location.reload();
                } else {
                    showNotification('error', 'Giriş başarısız. Lütfen tekrar deneyin.');
                }
            } catch (error) {
                console.error('Login hatası:', error);
                showNotification('error', 'Bir hata oluştu. Lütfen tekrar deneyin.');
            }
        });
    }

    const userMenu = document.getElementById('userMenu');
    const backdrop = document.getElementById('menuBackdrop');
    const userButton = document.querySelector('button[onclick="toggleUserMenu()"]');

    // Kullanıcı menüsünü aç/kapa
    userButton.addEventListener('click', function(event) {
        event.stopPropagation(); // Menüyü açarken tıklamayı durdur
        userMenu.classList.toggle('hidden');
        backdrop.classList.toggle('hidden');
    });

    // "Profilim" bağlantısına tıklama olayını dinle
    const profileLink = document.querySelector('#userMenu .profile-link');
    if (profileLink) {
        profileLink.addEventListener('click', function(event) {
            event.stopPropagation(); // Popup'ın kapanmasını engelle
            window.location.href = profileLink.getAttribute('href'); // Profil sayfasına yönlendir
        });
    }

    // Tıklama olayını dinle
    document.addEventListener('click', function(event) {
        if (!userMenu.contains(event.target) && !userButton.contains(event.target)) {
            // Kullanıcı menüsünün dışında bir yere tıklanırsa menüyü kapat
            userMenu.classList.add('hidden');
            backdrop.classList.add('hidden');
        }
    });

    // Kullanıcı menüsü toggle fonksiyonunu global scope'a ekle
    window.toggleUserMenu = function() {
        const userMenu = document.getElementById('userMenu');
        const backdrop = document.getElementById('menuBackdrop');
        const body = document.body;

        if (userMenu && backdrop) {
            userMenu.classList.toggle('hidden');
            backdrop.classList.toggle('hidden');
            
            // Body scroll lock
            if (!userMenu.classList.contains('hidden')) {
                body.style.overflow = 'hidden';
            } else {
                body.style.overflow = '';
            }
        }
    };

    function updateUserMenu() {
        const userMenu = document.getElementById('userMenu');
        const jwtToken = getCookie('jwt_token');
    
        if (userMenu) {
            if (jwtToken) {
                // Kullanıcı giriş yapmışsa
                userMenu.innerHTML = `
                    <div class="p-2">
                        <a href="/profile" class="flex items-center space-x-2 p-2 hover:bg-red-500/10 rounded transition duration-300 profile-link">
                            <i class="fa-solid fa-user w-5"></i>
                            <span class="text-sm">Profilim</span>
                        </a>
                        <form action="logout" method="post" class="w-full">
                            <button type="submit" class="w-full flex items-center space-x-2 p-2 hover:bg-red-500/10 rounded transition duration-300">
                                <i class="fa-solid fa-right-from-bracket w-5"></i>
                                <span class="text-sm">Çıkış Yap</span>
                            </button>
                        </form>
                    </div>
                `;
            } else {
                // Kullanıcı giriş yapmamışsa
                userMenu.innerHTML = `
                    <div class="p-3 border-b border-red-900/30">
                        <p class="text-sm text-gray-400">Hoş geldin!</p>
                        <p class="text-xs text-gray-500">Devam etmek için giriş yap</p>
                    </div>
                    <div class="p-2">
                        <a href="login" class="block flex items-center space-x-2 p-2 hover:bg-red-500/10 rounded transition duration-300">
                            <i class="fa-solid fa-right-to-bracket w-5"></i>
                            <span class="text-sm">Giriş Yap</span>
                        </a>
                        <a href="register" class="block flex items-center space-x-2 p-2 hover:bg-red-500/10 rounded transition duration-300">
                            <i class="fa-solid fa-user-plus w-5"></i>
                            <span class="text-sm">Kayıt Ol</span>
                        </a>
                    </div>
                `;
            }
        }
    }
    
    // User menu açıldığında hemen güncelle
    document.addEventListener('DOMContentLoaded', updateUserMenu);

    // Çıkış yapma fonksiyonu
    async function logout() {
        try {
            // Cookie'leri sil
            document.cookie = 'jwt_token=; path=/; expires=Thu, 01 Jan 1970 00:00:00 GMT';
            document.cookie = 'user_info=; path=/; expires=Thu, 01 Jan 1970 00:00:00 GMT';
            window.location.reload();
        } catch (error) {
            console.error('Logout hatası:', error);
            showNotification('error', 'Çıkış yapılırken bir hata oluştu.');
        }
    }

    // Cookie yardımcı fonksiyonları
    function getCookie(name) {
        const value = `; ${document.cookie}`;
        const parts = value.split(`; ${name}=`);
        if (parts.length === 2) return parts.pop().split(';').shift();
        return null;
    }

    // Bildirim gösterme fonksiyonu
    function showNotification(type, message) {
        const notification = document.createElement('div');
        notification.className = `fixed top-4 right-4 p-4 rounded-lg shadow-lg z-50 ${
            type === 'success' ? 'bg-green-500' : 'bg-red-500'
        } text-white`;
        
        notification.innerHTML = `
            <div class="flex items-center space-x-2">
                <span class="text-lg">
                    ${type === 'success' ? '✓' : '✕'}
                </span>
                <span>${message}</span>
            </div>
        `;
        
        document.body.appendChild(notification);
        
        // 3 saniye sonra bildirimi kaldır
        setTimeout(() => {
            notification.remove();
        }, 3000);
    }
});
