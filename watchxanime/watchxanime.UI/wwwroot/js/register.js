document.addEventListener('DOMContentLoaded', function() {
    console.log('Register.js yüklendi');
    const registerForm = document.querySelector('form[action="/register"]');
    
    // Sayfa yüklendiğinde URL'de success parametresi varsa başarılı bildirimini göster
    const urlParams = new URLSearchParams(window.location.search);
    if (urlParams.get('registerSuccess') === 'true') {
        showNotification('success', 'Kayıt işlemi başarıyla tamamlandı! Giriş yapabilirsiniz.');
        // URL'den parametreyi temizle
        window.history.replaceState({}, document.title, window.location.pathname);
    }
    
    if (registerForm) {
        console.log('Form bulundu');
        registerForm.addEventListener('submit', async function(e) {
            e.preventDefault();
            console.log('Form gönderiliyor...');

            // Form doğrulama
            const password = this.querySelector('#password').value;
            const confirmPassword = this.querySelector('#confirmPassword').value;
            const email = this.querySelector('#email').value;
            const userName = this.querySelector('#userName').value;
            const fullName = this.querySelector('#fullName').value;

            // Hata mesajlarını temizle
            clearErrors();

            // Doğrulama kontrolleri
            let hasError = false;

            if (!fullName || fullName.length < 2) {
                showFieldError('fullName', 'Ad Soyad en az 2 karakter olmalıdır');
                hasError = true;
            }

            if (!userName || userName.length < 3) {
                showFieldError('userName', 'Kullanıcı adı en az 3 karakter olmalıdır');
                hasError = true;
            }

            if (!validateEmail(email)) {
                showFieldError('email', 'Geçerli bir email adresi giriniz');
                hasError = true;
            }

            if (password.length < 8) {
                showFieldError('password', 'Şifre en az 8 karakter olmalıdır');
                hasError = true;
            }

            if (!/[A-Z]/.test(password)) {
                showFieldError('password', 'Şifre en az bir büyük harf içermelidir');
                hasError = true;
            }

            if (!/[0-9]/.test(password)) {
                showFieldError('password', 'Şifre en az bir rakam içermelidir');
                hasError = true;
            }

            if (!/[!@#$%^&*]/.test(password)) {
                showFieldError('password', 'Şifre en az bir özel karakter içermelidir (!@#$%^&*)');
                hasError = true;
            }

            if (password !== confirmPassword) {
                showFieldError('confirmPassword', 'Şifreler eşleşmiyor');
                hasError = true;
            }

            if (hasError) {
                showNotification('error', 'Lütfen form hatalarını düzeltin');
                return;
            }

            try {
                const formData = new FormData(this);
                const response = await fetch('/register', {
                    method: 'POST',
                    body: formData
                });

                if (response.ok) {
                    console.log('Kayıt başarılı');
                    showNotification('success', 'Kayıt işlemi başarıyla tamamlandı! Giriş yapabilirsiniz.');
                    
                    // Modal'ı kapat
                    setTimeout(() => {
                        const modal = document.getElementById('registerModal');
                        if (modal) {
                            modal.classList.add('hidden');
                        }
                    }, 2000);

                    // Formu temizle
                    this.reset();
                } else {
                    const errorText = await response.text();
                    console.log('Kayıt hatası:', errorText);
                    showNotification('error', 'Kayıt işlemi başarısız oldu. ' + errorText);
                }
            } catch (error) {
                console.error('Hata oluştu:', error);
                showNotification('error', 'Bir hata oluştu. Lütfen tekrar deneyin.');
            }
        });
    } else {
        console.error('Kayıt formu bulunamadı!');
    }
});

// Email doğrulama fonksiyonu
function validateEmail(email) {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
}

// Hata mesajlarını temizle
function clearErrors() {
    const errorMessages = document.querySelectorAll('.error-message');
    errorMessages.forEach(msg => msg.remove());
    
    const inputs = document.querySelectorAll('input');
    inputs.forEach(input => {
        input.classList.remove('border-red-500');
        input.classList.add('border-red-900/30');
    });
}

// Alan için hata mesajı göster
function showFieldError(fieldId, message) {
    const field = document.getElementById(fieldId);
    if (field) {
        // Varolan hata mesajını kaldır
        const existingError = field.parentElement.querySelector('.error-message');
        if (existingError) {
            existingError.remove();
        }

        // Input stilini güncelle
        field.classList.remove('border-red-900/30');
        field.classList.add('border-red-500');

        // Yeni hata mesajı ekle
        const errorDiv = document.createElement('div');
        errorDiv.className = 'error-message text-red-500 text-xs mt-1';
        errorDiv.textContent = message;
        field.parentElement.appendChild(errorDiv);
    }
}

function showNotification(type, message) {
    // Önce eski bildirimi kaldır
    const existingNotification = document.querySelector('.notification');
    if (existingNotification) {
        existingNotification.remove();
    }

    // Yeni bildirim oluştur
    const notification = document.createElement('div');
    notification.className = `notification fixed top-4 right-4 p-4 rounded-lg shadow-lg z-[9999] ${
        type === 'success' ? 'bg-green-500' : 'bg-red-500'
    } text-white text-sm font-medium animate-fade-in`;
    
    // İkon ve mesaj içeriği
    notification.innerHTML = `
        <div class="flex items-center space-x-2">
            <span class="flex-shrink-0">
                ${type === 'success' 
                    ? '<i class="fas fa-check-circle"></i>' 
                    : '<i class="fas fa-exclamation-circle"></i>'}
            </span>
            <span>${message}</span>
        </div>
    `;

    // Bildirimi sayfaya ekle
    document.body.appendChild(notification);

    // CSS animasyonu için stil ekle
    const style = document.createElement('style');
    style.textContent = `
        @keyframes fadeIn {
            from { opacity: 0; transform: translateY(-20px); }
            to { opacity: 1; transform: translateY(0); }
        }
        .animate-fade-in {
            animation: fadeIn 0.3s ease-out forwards;
        }
    `;
    document.head.appendChild(style);

    // 3 saniye sonra bildirimi kaldır
    setTimeout(() => {
        notification.style.opacity = '0';
        notification.style.transform = 'translateY(-20px)';
        notification.style.transition = 'all 0.3s ease-out';
        
        setTimeout(() => {
            notification.remove();
        }, 300);
    }, 3000);
}