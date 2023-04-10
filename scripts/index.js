// Other
let isOpen = false;

function seeMoreAddress() {
    const addressItems = document.querySelectorAll('.contacts__address-item:nth-child(3), .contacts__address-item:nth-child(4)');
    addressItems.forEach(item => {
        item.style.display = isOpen ? 'none' : 'block';
    });
    isOpen = !isOpen;
}

// Burger menu
const body = document.querySelector('body');
const menu = document.querySelector('.header__mob');

function openMenu() {
    body.style.overflowY = 'hidden';
    menu.classList.add('active');
}

function closeMenu() {
    body.style.overflowY = 'auto';
    menu.classList.replace('active', 'remove');
}

// Slider
$(document).ready(function () {
    $('.shop__slider').slick(
        {
            slidesToShow: 3,
            touchThreshold: 50,
            responsive: [
                {
                    breakpoint: 1100,
                    settings: {
                        slidesToShow: 2
                    },
                },
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 1
                    },
                }
            ]
        }
    );

});
