window.addEventListener('load', () => {
    let kindsXhr = new XMLHttpRequest();
    kindsXhr.open('GET', 'http://217.71.129.139:4834/coffeeshop-webapi/kinds', true);
    kindsXhr.setRequestHeader('content-type', 'application/json');
    kindsXhr.send();
    kindsXhr.onload = function () {
        if (kindsXhr.status !== 200) {
            alert(`Error ${kindsXhr.status}: ${kindsXhr.statusText}`);
        } else {
            const kindsData = JSON.parse(kindsXhr.response);
            for (let i = 0; i < kindsData.length; i++) {
                const block = document.querySelector('.form__select-product');
                const content = `<option value="${kindsData[i].title}" class="form__select-option">${kindsData[i].title}</option>`

                block.innerHTML += content;
            }

            const productOptions = document.querySelectorAll('.form__select-product .form__select-option');
            const value = window.localStorage.getItem('product');
            console.log(value)
            if (value !== null) {
                for (let i = 0; i < productOptions.length; i++) {
                    if (productOptions[i].value === value) {
                        productOptions[i].selected = true;
                    }
                }
            }
        }
    };

    let paymentXhr = new XMLHttpRequest();
    paymentXhr.open('GET', 'http://217.71.129.139:4834/coffeeshop-webapi/payment-methods', true);
    paymentXhr.setRequestHeader('content-type', 'application/json');
    paymentXhr.send();
    paymentXhr.onload = function () {
        if (paymentXhr.status !== 200) {
            alert(`Error ${paymentXhr.status}: ${paymentXhr.statusText}`);
        } else {
            const paymentData = JSON.parse(paymentXhr.response);
            for (let i = 0; i < paymentData.length; i++) {
                const block = document.querySelector('.form__select-payment-method');
                const content = `<option value="${paymentData[i].name}" class="form__select-option">${paymentData[i].name}</option>`

                block.innerHTML += content;
            }
        }
    };
});

function sendOrder() {
    const name = document.querySelector('#name').value;
    const phone = document.querySelector('#phone').value;
    const email = document.querySelector('#email').value;
    const address = document.querySelector('#address').value;
    const date = document.querySelector('#date').value;
    const product = document.querySelector('#product');
    const paymentMethod = document.querySelector('#payment-method');
    const additional = document.querySelector('#additional').value;

    const data = JSON.stringify({
        name: name,
        phone: phone,
        email: email,
        address: address,
        date: date,
        kindId: product.selectedIndex + 1,
        paymentMethodId: paymentMethod.selectedIndex + 1,
        additional: additional
    })

    let xhr = new XMLHttpRequest();
    xhr.open('POST', 'http://217.71.129.139:4834/coffeeshop-webapi/orders', true);
    xhr.setRequestHeader('content-type', 'application/json; charset=utf-8');

    xhr.onload = function () {
        alert(`Thank you for your order! We will contact you shortly to confirm the details of delivery!`);
        window.location.href = '../index.html'
    };

    xhr.onerror = function () {
        alert(`Connection error`);
    };

    xhr.send(data);
}
