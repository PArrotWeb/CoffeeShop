$(document).ready(function () {
    $('.shop__slider').slick(
        {
            slidesToShow: 3,
            touchThreshold: 20,
            responsive: [
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 2
                    },
                    breakpoint: 500,
                    settings: {
                        slidesToShow: 1
                    }
                }
            ]
        }
    );

});