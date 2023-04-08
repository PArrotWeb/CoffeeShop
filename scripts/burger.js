const body = document.querySelector('body');
const menu = document.querySelector('.header__mob');

function openMenu() {
    // body.style.overflowY = 'hidden';
    menu.classList.add('active');
}

function closeMenu() {
    // body.style.overflowY = 'auto';
    menu.classList.replace('active', 'remove');
}