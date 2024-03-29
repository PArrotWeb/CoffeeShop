const serverUrl = 'http://217.71.129.139:4578';

// Other
let isOpen = false;

function seeMoreAddress() {
    const addressItems = document.querySelectorAll('.contacts__address-item:nth-child(3), .contacts__address-item:nth-child(4)');
    addressItems.forEach(item => {
        item.style.display = isOpen ? 'none' : 'block';
    });
    isOpen = !isOpen;
}

// set value to select
function setValueToSelect(value) {
    const storage = window.localStorage;
    storage.setItem('product', value);
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
function initSlider() {
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
}

$(document).ready(function () {
    let xhr = new XMLHttpRequest();
    xhr.open('GET', `${serverUrl}/kinds`, true);
    xhr.setRequestHeader('content-type', 'application/json');
    xhr.send();
    xhr.onload = function () {
        if (xhr.status !== 200) {
            // alert(`Error ${xhr.status}: ${xhr.statusText}`);
        } else {
            const data = JSON.parse(xhr.response);
            for (let i = 0; i < data.length; i++) {
                const block = document.querySelector('.shop__slider');
                const content = `<div class="shop__slider-item"><div class="shop__slider-item-card"><p class="shop__slider-item-title">
			    ${data[i].title}</p><p class="shop__slider-item-description">${data[i].description}</p>
			    <a class="shop__slider-item-btn btn" href="frontend/order.html" onclick="setValueToSelect('${data[i].title}')">
			    Order now</a></div>`

                block.innerHTML += content;
            }

            initSlider();
        }
    };
});


