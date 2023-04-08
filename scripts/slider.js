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