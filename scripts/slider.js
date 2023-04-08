$(document).ready(function () {
    $('.shop__slider').slick(
        {
            slidesToShow: 1,
            touchThreshold: 20,
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