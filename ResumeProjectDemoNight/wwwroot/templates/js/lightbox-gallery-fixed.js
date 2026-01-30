// ===================================================
// LIGHTBOX GALLERY - FULL WORKING VERSION
// ===================================================

(function () {
    'use strict';

    // STEP 1: Lightbox Gallery Class
    class LightboxGallery {
        constructor() {
            this.currentIndex = 0;
            this.images = [];
            this.lightboxElement = null;
            this.init();
        }

        init() {
            this.createLightboxHTML();
            this.attachEventListeners();
        }

        createLightboxHTML() {
            const lightboxHTML = `
                <div id="lightbox-overlay" class="lightbox-overlay">
                    <div class="lightbox-container">
                        <button class="lightbox-close" aria-label="Kapat">
                            <i class="fas fa-times"></i>
                        </button>
                        
                        <button class="lightbox-nav lightbox-prev" aria-label="Önceki">
                            <i class="fas fa-chevron-left"></i>
                        </button>
                        
                        <button class="lightbox-nav lightbox-next" aria-label="Sonraki">
                            <i class="fas fa-chevron-right"></i>
                        </button>
                        
                        <div class="lightbox-content">
                            <img src="" alt="" class="lightbox-image">
                            <div class="lightbox-counter"></div>
                        </div>
                        
                        <div class="lightbox-thumbnails"></div>
                    </div>
                </div>
            `;

            document.body.insertAdjacentHTML('beforeend', lightboxHTML);
            this.lightboxElement = document.getElementById('lightbox-overlay');
            console.log('✅ Lightbox HTML oluşturuldu');
        }

        attachEventListeners() {
            // Close button
            this.lightboxElement.querySelector('.lightbox-close').addEventListener('click', () => this.close());

            // Navigation buttons
            this.lightboxElement.querySelector('.lightbox-prev').addEventListener('click', () => this.prev());
            this.lightboxElement.querySelector('.lightbox-next').addEventListener('click', () => this.next());

            // Overlay click to close
            this.lightboxElement.addEventListener('click', (e) => {
                if (e.target === this.lightboxElement) {
                    this.close();
                }
            });

            // Keyboard navigation
            document.addEventListener('keydown', (e) => {
                if (!this.lightboxElement.classList.contains('active')) return;

                switch (e.key) {
                    case 'Escape':
                        this.close();
                        break;
                    case 'ArrowLeft':
                        this.prev();
                        break;
                    case 'ArrowRight':
                        this.next();
                        break;
                }
            });

            console.log('✅ Event listeners eklendi');
        }

        open(images, startIndex = 0) {
            console.log('🖼️ Lightbox açılıyor, resim sayısı:', images.length);
            this.images = images;
            this.currentIndex = startIndex;

            // Prevent body scroll
            document.body.style.overflow = 'hidden';

            // Show lightbox
            this.lightboxElement.classList.add('active');

            // Render content
            this.renderImage();
            this.renderThumbnails();

            // Trigger animation
            setTimeout(() => {
                this.lightboxElement.classList.add('visible');
            }, 10);
        }

        close() {
            console.log('❌ Lightbox kapatılıyor');
            this.lightboxElement.classList.remove('visible');

            setTimeout(() => {
                this.lightboxElement.classList.remove('active');
                document.body.style.overflow = '';
            }, 300);
        }

        prev() {
            this.currentIndex = (this.currentIndex - 1 + this.images.length) % this.images.length;
            this.renderImage();
            this.updateThumbnails();
        }

        next() {
            this.currentIndex = (this.currentIndex + 1) % this.images.length;
            this.renderImage();
            this.updateThumbnails();
        }

        renderImage() {
            const img = this.lightboxElement.querySelector('.lightbox-image');
            const counter = this.lightboxElement.querySelector('.lightbox-counter');

            // Fade out
            img.style.opacity = '0';

            setTimeout(() => {
                img.src = this.images[this.currentIndex];
                img.alt = `Görsel ${this.currentIndex + 1}`;
                counter.textContent = `${this.currentIndex + 1} / ${this.images.length}`;

                // Fade in
                img.onload = () => {
                    img.style.opacity = '1';
                };
            }, 150);
        }

        renderThumbnails() {
            const container = this.lightboxElement.querySelector('.lightbox-thumbnails');
            container.innerHTML = '';

            this.images.forEach((src, index) => {
                const thumb = document.createElement('div');
                thumb.className = 'lightbox-thumb';
                if (index === this.currentIndex) {
                    thumb.classList.add('active');
                }

                const img = document.createElement('img');
                img.src = src;
                img.alt = `Thumbnail ${index + 1}`;

                thumb.appendChild(img);
                thumb.addEventListener('click', () => {
                    this.currentIndex = index;
                    this.renderImage();
                    this.updateThumbnails();
                });

                container.appendChild(thumb);
            });
        }

        updateThumbnails() {
            const thumbs = this.lightboxElement.querySelectorAll('.lightbox-thumb');
            thumbs.forEach((thumb, index) => {
                if (index === this.currentIndex) {
                    thumb.classList.add('active');
                } else {
                    thumb.classList.remove('active');
                }
            });
        }
    }

    // STEP 2: Initialize Lightbox First
    function initializeLightbox() {
        console.log('🚀 Lightbox başlatılıyor...');
        window.lightboxGallery = new LightboxGallery();
        console.log('✅ window.lightboxGallery oluşturuldu:', window.lightboxGallery);
    }

    // STEP 3: Setup Modal Gallery Events
    function setupModalGalleryEvents() {
        console.log('🎯 Modal gallery event\'leri ayarlanıyor...');

        // jQuery ile tüm modallara event ekle
        $(document).on('shown.bs.modal', '.modal', function () {
            console.log('📂 Modal açıldı');

            var modal = this;
            var galleryContainer = modal.querySelector('[data-gallery-id]');

            if (!galleryContainer) {
                console.log('⚠️ Bu modalda gallery yok');
                return;
            }

            console.log('✅ Gallery container bulundu:', galleryContainer.getAttribute('data-gallery-id'));

            // Tüm resimleri topla
            var attachmentItems = galleryContainer.querySelectorAll('.attachment-item');

            if (attachmentItems.length === 0) {
                console.log('⚠️ Hiç resim bulunamadı');
                return;
            }

            var images = [];
            attachmentItems.forEach(function (item) {
                images.push(item.src);
            });

            console.log('📸 Toplam resim sayısı:', images.length);
            console.log('🖼️ Resimler:', images);

            // Her resme click event ekle
            attachmentItems.forEach(function (item, index) {
                // Önceki click event'i kaldır
                item.style.cursor = 'pointer';

                // Yeni event ekle
                item.onclick = function (e) {
                    e.preventDefault();
                    console.log('🎯 Resim #' + (index + 1) + ' tıklandı');

                    if (window.lightboxGallery) {
                        console.log('✅ Lightbox açılıyor...');
                        window.lightboxGallery.open(images, index);
                    } else {
                        console.error('❌ window.lightboxGallery bulunamadı!');
                        alert('Lightbox yüklenemedi! Lütfen sayfayı yenileyin.');
                    }
                };
            });

            console.log('✅ Click event\'leri eklendi');
        });
    }

    // STEP 4: Start Everything
    function startLightboxSystem() {
        console.log('='.repeat(50));
        console.log('LIGHTBOX GALLERY SYSTEM BAŞLATILIYOR');
        console.log('='.repeat(50));

        // Önce lightbox'ı oluştur
        initializeLightbox();

        // Sonra modal event'lerini setup et
        setupModalGalleryEvents();

        console.log('='.repeat(50));
        console.log('✅ TÜM SİSTEM HAZIR!');
        console.log('='.repeat(50));
    }

    // Wait for document ready
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', startLightboxSystem);
    } else {
        // jQuery ready kullan (Bootstrap zaten jQuery gerektiriyor)
        $(document).ready(startLightboxSystem);
    }

})();