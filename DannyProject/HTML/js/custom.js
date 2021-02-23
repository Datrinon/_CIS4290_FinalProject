/*

Qwilo - Multipurpose Responsive HTML5 Template
Author: iqonicthemes.in
Version: 1.0
Design and Developed by: iqonicthemes.in

*/
/*================================================
[  Table of contents  ]
================================================
:: Wow Animation
:: Page loader
:: Back to top
:: Tooltip
:: Shopping Cart
:: Jarallax
:: Searchstyle Bar
:: Menu Bar
:: Sidebar Menu
:: Counters
:: CountdownTimer
:: Isotope
:: Masonry
:: Portfolio move
:: ProgressBar
:: Audiovideo
:: Accordion
:: owl carousel 
:: Magnific Popup
:: typer
:: Contact from


======================================
[ End table content ]
======================================*/
$(document).ready(function() {
"use strict";
$(window).on('load', function() {

        /*---------------------
         Wow Animation
        -----------------------*/

        var wow = new WOW({
            boxClass: 'wow',
            animateClass: 'animated',
            offset: 0,
            mobile: false,
            live: true
        });
        wow.init();
    });
 /*------------------------
    Page Loader
    --------------------------*/
    jQuery("#load").fadeOut();
    jQuery("#loading").delay(0).fadeOut("slow");



 /*------------------------
    Back To Top
    --------------------------*/
    $('#back-to-top').fadeOut();
    $(window).on("scroll", function() {
        if ($(this).scrollTop() > 250) {
            $('#back-to-top').fadeIn(1400);
        } else {
            $('#back-to-top').fadeOut(400);
        }
    });
    // scroll body to 0px on click
    $('#top').on('click', function() {
        $('top').tooltip('hide');
        $('body,html').animate({
            scrollTop: 0
        }, 800);
        return false;
    });

 /*------------------------
    Slick slider
    --------------------------*/
    if ($('div').hasClass('slider-for')) {
        $('.slider-for').slick({
            slidesToShow: 1,
            slidesToScroll: 1,
            arrows: false,
            fade: true,
            asNavFor: '.slider-nav'
        });
    }
    //if(document.getElementsByClassName("slider-nav") != null) {
    if ($('div').hasClass('slider-nav')) {
        $('.slider-nav').slick({
            slidesToShow: 4,
            slidesToScroll: 1,
            asNavFor: '.slider-for',
            dots: true,
            centerMode: true,
            focusOnSelect: true
        });
    }
    // if(document.getElementsByClassName("responsive") != null) {
    if ($('div').hasClass('responsive')) {
        $('.responsive').slick({
            dots: true,
            infinite: false,
            speed: 300,
            slidesToShow: 4,
            slidesToScroll: 1,
            responsive: [{
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 1,
                        infinite: true,
                        dots: true
                    }
                }, {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1
                    }
                }, {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                }

            ]
        });
    }

    /*------------------------
    Rangslider
    --------------------------*/
    if (document.getElementById("mySlider") != null) {

        $("#mySlider").slider({
            range: true,
            min: 10,
            max: 999,
            values: [200, 500],
            slide: function(event, ui) {
                $("#price").val("$" + ui.values[0] + " - $" + ui.values[1]);
            }
        });

        $("#price").val("$" + $("#mySlider").slider("values", 0) +
            " - $" + $("#mySlider").slider("values", 1));

    }

    /*------------------------
    Shopslider
    --------------------------*/
    $('.indc .increment, .indc1 .increment, .indc2 .increment, .indc3 .increment, .indc4 .increment, .indc5 .increment').click(function(e) {
        e.preventDefault();
        var fieldName = $(this).attr('field');
        var currentVal = parseInt($(this).prev().val());
        if (!isNaN(currentVal)) {
            $(this).prev().val(currentVal + 1);
        } else {
            $(this).prev().val(0);
        }
    });

    $('.indc .decrement, .indc1 .decrement, .indc2 .decrement, .indc3 .decrement, .indc4 .decrement, .indc5 .decrement').click(function(e) {
        e.preventDefault();
        var fieldName = $(this).attr('field');
        var currentVal = parseInt($(this).next().val());
        if (!isNaN(currentVal) && currentVal > 0) {
            $(this).next().val(currentVal - 1);
        } else {
            $(this).next().val(0);
        }
    });





 /*------------------------
    Cart Tooltip
    --------------------------*/
    $("#cart").on("click", function() {
        $(".cart-box").fadeToggle("fast");
    });


 /*------------------------
    Tooltip
    --------------------------*/
    $('[data-toggle="tooltip"]').tooltip()

/*------------------------
    Jarallax
    --------------------------*/
    $('.jarallax').jarallax({
        speed: 0.2
    });


/*------------------------
    Searchstyle Bar
    --------------------------*/
    'use strict';
    if ($(".search__input").length > 0) {
        var openCtrl = document.getElementById('btn-search'),
            closeCtrl = document.getElementById('btn-search-close'),
            searchContainer = document.querySelector('.search'),
            inputSearch = searchContainer.querySelector('.search__input');

        function init() {
            initEvents();
        }

        function initEvents() {
            openCtrl.addEventListener('click', openSearch);
            closeCtrl.addEventListener('click', closeSearch);
            document.addEventListener('keyup', function(ev) {
                // escape key.
                if (ev.keyCode === 27) {
                    closeSearch();
                }
            });
        }

        function openSearch() {
            searchContainer.classList.add('search--open');
            inputSearch.focus();
        }

        function closeSearch() {
            searchContainer.classList.remove('search--open');
            inputSearch.blur();
            inputSearch.value = '';
        }

        init();
    }

    // search 2
    $(".iq-search").on('click', function() {
        var checkId = document.getElementsByClassName("search-open");
        if (checkId.length > 0) {
            $('.iq-search').removeClass("search-open");
        } else {
            $('.iq-search').addClass("search-open");
        }
    })


 /*------------------------
    Menu Bar
    --------------------------*/
    jQuery('#menu-1').megaMenu({
        // DESKTOP MODE SETTINGS
        logo_align: 'left', // align the logo left or right. options (left) or (right)
        links_align: 'left', // align the links left or right. options (left) or (right)
        socialBar_align: 'left', // align the socialBar left or right. options (left) or (right)
        searchBar_align: 'right', // align the search bar left or right. options (left) or (right)
        trigger: 'hover', // show drop down using click or hover. options (hover) or (click)
        effect: 'fade', // drop down effects. options (fade), (scale), (expand-top), (expand-bottom), (expand-left), (expand-right)
        effect_speed: 400, // drop down show speed in milliseconds
        sibling: true, // hide the others showing drop downs if this option true. this option works on if the trigger option is "click". options (true) or (false)
        outside_click_close: true, // hide the showing drop downs when user click outside the menu. this option works if the trigger option is "click". options (true) or (false)
        top_fixed: false, // fixed the menu top of the screen. options (true) or (false)
        sticky_header: true, // menu fixed on top when scroll down down. options (true) or (false)
        sticky_header_height: 200, // sticky header height top of the screen. activate sticky header when meet the height. option change the height in px value.
        menu_position: 'horizontal', // change the menu position. options (horizontal), (vertical-left) or (vertical-right)
        full_width: true, // make menu full width. options (true) or (false)
        // MOBILE MODE SETTINGS
        mobile_settings: {
            collapse: true, // collapse the menu on click. options (true) or (false)
            sibling: true, // hide the others showing drop downs when click on current drop down. options (true) or (false)
            scrollBar: true, // enable the scroll bar. options (true) or (false)
            scrollBar_height: 400, // scroll bar height in px value. this option works if the scrollBar option true.
            top_fixed: false, // fixed menu top of the screen. options (true) or (false)
            sticky_header: true, // menu fixed on top when scroll down down. options (true) or (false)
            sticky_header_height: 200 // sticky header height top of the screen. activate sticky header when meet the height. option change the height in px value.
        }
    });
    $('#menu-2').megaMenu({
        // DESKTOP MODE SETTINGS
        logo_align: 'left', // align the logo left or right. options (left) or (right)
        links_align: 'left', // align the links left or right. options (left) or (right)
        socialBar_align: 'left', // align the socialBar left or right. options (left) or (right)
        searchBar_align: 'right', // align the search bar left or right. options (left) or (right)
        trigger: 'hover', // show drop down using click or hover. options (hover) or (click)
        effect: 'fade', // drop down effects. options (fade), (scale), (expand-top), (expand-bottom), (expand-left), (expand-right)
        effect_speed: 400, // drop down show speed in milliseconds
        sibling: true, // hide the others showing drop downs if this option true. this option works on if the trigger option is "click". options (true) or (false)
        outside_click_close: true, // hide the showing drop downs when user click outside the menu. this option works if the trigger option is "click". options (true) or (false)
        top_fixed: false, // fixed the menu top of the screen. options (true) or (false)
        sticky_header: false, // menu fixed on top when scroll down down. options (true) or (false)
        sticky_header_height: 200, // sticky header height top of the screen. activate sticky header when meet the height. option change the height in px value.
        menu_position: 'vertical-right', // change the menu position. options (horizontal), (vertical-left) or (vertical-right)
        full_width: false, // make menu full width. options (true) or (false)
        // MOBILE MODE SETTINGS
        mobile_settings: {
            collapse: true, // collapse the menu on click. options (true) or (false)
            sibling: true, // hide the others showing drop downs when click on current drop down. options (true) or (false)
            scrollBar: true, // enable the scroll bar. options (true) or (false)
            scrollBar_height: 400, // scroll bar height in px value. this option works if the scrollBar option true.
            top_fixed: false, // fixed menu top of the screen. options (true) or (false)
            sticky_header: false, // menu fixed on top when scroll down down. options (true) or (false)
            sticky_header_height: 200 // sticky header height top of the screen. activate sticky header when meet the height. option change the height in px value.
        }
    });
    $('#menu-3').megaMenu({
        // DESKTOP MODE SETTINGS
        logo_align: 'left', // align the logo left or right. options (left) or (right)
        links_align: 'left', // align the links left or right. options (left) or (right)
        socialBar_align: 'left', // align the socialBar left or right. options (left) or (right)
        searchBar_align: 'right', // align the search bar left or right. options (left) or (right)
        trigger: 'hover', // show drop down using click or hover. options (hover) or (click)
        effect: 'fade', // drop down effects. options (fade), (scale), (expand-top), (expand-bottom), (expand-left), (expand-right)
        effect_speed: 400, // drop down show speed in milliseconds
        sibling: true, // hide the others showing drop downs if this option true. this option works on if the trigger option is "click". options (true) or (false)
        outside_click_close: true, // hide the showing drop downs when user click outside the menu. this option works if the trigger option is "click". options (true) or (false)
        top_fixed: false, // fixed the menu top of the screen. options (true) or (false)
        sticky_header: false, // menu fixed on top when scroll down down. options (true) or (false)
        sticky_header_height: 200, // sticky header height top of the screen. activate sticky header when meet the height. option change the height in px value.
        menu_position: 'vertical-left', // change the menu position. options (horizontal), (vertical-left) or (vertical-right)
        full_width: false, // make menu full width. options (true) or (false)
        // MOBILE MODE SETTINGS
        mobile_settings: {
            collapse: true, // collapse the menu on click. options (true) or (false)
            sibling: true, // hide the others showing drop downs when click on current drop down. options (true) or (false)
            scrollBar: true, // enable the scroll bar. options (true) or (false)
            scrollBar_height: 400, // scroll bar height in px value. this option works if the scrollBar option true.
            top_fixed: false, // fixed menu top of the screen. options (true) or (false)
            sticky_header: false, // menu fixed on top when scroll down down. options (true) or (false)
            sticky_header_height: 200 // sticky header height top of the screen. activate sticky header when meet the height. option change the height in px value.
        }
    });

/*------------------------
    Sidebar Menu
    --------------------------*/
    $(".sider-bt").on("click", function() {
        $(".sider-bt").toggleClass("cross");
        $(".sidebar-menu").toggleClass("sidebar-open");
    });

/*************************
Counters
*************************/

    $('.timer').countTo();



/*************************
CountdownTimer
*************************/

    $('#countdown').countdown({
        date: '10/01/2019 23:59:59',
        offset: -8,
        day: 'Day',
        days: 'Days'
    });
    $('#iq-countdown1').countdown({
        date: '01/01/2019 23:59:59',
        offset: -8,
        day: 'Day',
        days: 'Days'
    });
    $('#iq-countdown2').countdown({
        date: '01/01/2019 23:59:59',
        offset: -8,
        day: 'Day',
        days: 'Days'
    });
    $('#iq-countdown3').countdown({
        date: '01/01/2019 23:59:59',
        offset: -8,
        day: 'Day',
        days: 'Days'
    });



/*************************
Isotope
*************************/

    var $isotope = $(".isotope"),
        $itemElement = '.iq-grid-item',
        $filters = $('.isotope-filters');
    if ($isotope) {
        $isotope.isotope({
            resizable: true,
            itemSelector: $itemElement,
            masonry: {
                gutterWidth: 10
            }
        });
        $filters.on('click', 'button', function() {
            var $val = $(this).attr('data-filter');
            $isotope.isotope({
                filter: $val
            });
            $filters.find('.active').removeClass('active');
            $(this).addClass('active');
        });
    }



/*************************
Masonry
*************************/

    var $masonry = $('.iq-masonry-block .iq-masonry'),
        $itemElement = '.iq-masonry-block .iq-masonry-item',
        $filters = $('.iq-masonry-block .isotope-filters');
    if ($masonry) {
        $masonry.isotope({
            percentPosition: true,
            resizable: true,
            itemSelector: $itemElement,
            masonry: {
                gutterWidth: 0
            }
        });
        // bind filter button click
        $filters.on('click', 'button', function() {
            var filterValue = $(this).attr('data-filter');
            $masonry.isotope({
                filter: filterValue
            });
        });

        $filters.each(function(i, buttonGroup) {
            var $buttonGroup = $(buttonGroup);
            $buttonGroup.on('click', 'button', function() {
                $buttonGroup.find('.active').removeClass('active');
                $(this).addClass('active');
            });
        });
    }



/*************************
Portfolio move
*************************/

    $('.iq-portfolio-05').each(function() {
        $(this).hoverdir({});
    });




/*************************
ProgressBar
*************************/

    jQuery('.progress-bar').each(function(i, elem) {
        var $elem = $(this),
            percent = $elem.attr('data-percent') || "100",
            delay = $elem.attr('data-delay') || "100",
            type = $elem.attr('data-type') || "%";

        if (!$elem.hasClass('progress-animated')) {
            $elem.css({
                'width': '0%'
            });
        }

        var progressBarRun = function() {
            $elem.animate({
                'width': percent + '%'
            }, 'easeInOutCirc').addClass('progress-animated');

            $elem.delay(delay).append('<span class="progress-type animated fadeIn">' + type + '</span><span class="progress-number animated fadeIn">' + percent + '</span>');
        };

        $(elem).appear(function() {
            setTimeout(function() {
                progressBarRun();
            }, delay);
        });
    });





/*************************
Audio video
*************************/

    if ($(".audio-video").length != 0) {
        $('audio,video').mediaelementplayer();
    }





/*************************
Accordion
*************************/

    var $acpanel = $(".iq-accordion .iq-ad-block > .ad-details"),
        $acsnav = $(".iq-accordion .iq-ad-block > .ad-title");

    $acpanel.hide().first().slideDown("easeOutExpo");
    $acsnav.first().addClass("iq-active");
    $acsnav.on('click', function() {
        var $this = $(this).next(".ad-details");
        $acsnav.parent().removeClass("iq-active");
        $(this).parent().addClass("iq-active");
        $acpanel.not($this).slideUp("easeInExpo");
        $(this).next().slideDown("easeOutExpo");
        return false;
    });




/*************************
owl carousel 
*************************/

    $(".owl-carousel").each(function() {
        var $this = $(this),
            $items = ($this.data('items')) ? $this.data('items') : 1,
            $loop = ($this.data('loop')) ? $this.data('loop') : true,
            $navdots = ($this.data('nav-dots')) ? $this.data('nav-dots') : false,
            $navarrow = ($this.data('nav-arrow')) ? $this.data('nav-arrow') : false,
            $autoplay = ($this.attr('data-autoplay')) ? $this.data('autoplay') : true,
            $space = ($this.attr('data-space')) ? $this.data('space') : 15;
        $(this).owlCarousel({
            loop: $loop,
            items: $items,
            responsive: {
                0: {
                    items: $this.data('xx-items') ? $this.data('xx-items') : 1
                },
                600: {
                    items: $this.data('xs-items') ? $this.data('xs-items') : 1
                },
                767: {
                    items: $this.data('sm-items') ? $this.data('sm-items') : 2
                },
                992: {
                    items: $this.data('md-items') ? $this.data('md-items') : 2
                },
                1190: {
                    items: $this.data('lg-items') ? $this.data('lg-items') : 3
                },
                1200: {
                    items: $items
                }
            },
            dots: $navdots,
            margin: $space,
            nav: $navarrow,
            navText: ["<i class='fa fa-angle-left fa-2x'></i>", "<i class='fa fa-angle-right fa-2x'></i>"],
            autoplay: $autoplay,
            autoplayHoverPause: true
        });

    });









/*************************
Magnific Popup
*************************/

    $('.popup-gallery').magnificPopup({
        delegate: 'a.popup-img',
        type: 'image',
        tLoading: 'Loading image #%curr%...',
        mainClass: 'mfp-img-mobile',
        gallery: {
            enabled: true,
            navigateByImgClick: true,
            preload: [0, 1] // Will preload 0 - before current, and 1 after the current image
        },
    });

    $('.popup-youtube, .popup-vimeo, .popup-gmaps').magnificPopup({
        disableOn: 700,
        type: 'iframe',
        mainClass: 'mfp-fade',
        removalDelay: 160,
        preloader: false,
        fixedContentPos: false
    });



/*************************
  typer
*************************/

    var foo;
    var win = $(window),
        foo = $('#typer');
    if (foo !== undefined)
        foo.typer(['<h6 class="iq-tw-6"><span class="iq-font-green">Web</span> Developer</h6>', '<h6 class="iq-tw-6">Web <span class="iq-font-green">Designer</span></h6>', '<h6 class="iq-tw-6"><span class="iq-font-green">Frontend</span> Developer</h6>']);




/*************************
  Contact from
*************************/

    $('#contact').submit(function(e) {
        var flag = 0;
        e.preventDefault(); // Prevent Default Submission
        $('.require').each(function() {
            if ($.trim($(this).val()) == '') {
                $(this).css("border", "1px solid red");
                e.preventDefault(); // Prevent Default Submission
                flag = 1;
            } else {
                $(this).css("border", "1px solid grey");
                flag = 0;
            }
        });

        if (grecaptcha.getResponse() == "") {
            flag = 1;
            alert('Please verify Recaptch');

        } else {
            flag = 0;
        }

        if (flag == 0) {
            $.ajax({
                    url: 'contact-form.php',
                    type: 'POST',
                    data: $("#contact").serialize() // it will serialize the form data
                })
                .done(function(data) {
                    $("#result").html('Form was successfully submitted.');
                    $('#contact')[0].reset();
                })
                .fail(function() {
                    alert('Ajax Submit Failed ...');
                });
        }

    });



/************************************
quntity increment decrement
**********************************/

   $(document).ready(function(){
var quantitiy=0;
   $('.quantity-right-plus').click(function(e){

        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        var quantity = parseInt($(this).parent().parent().find('.quantity').val());

        // If is not undefined

        $(this).parent().parent().find('.quantity').val(quantity + 1);
      
        // Increment
    
});

 $('.quantity-left-minus').click(function(e){
    // Stop acting like a button
    e.preventDefault();
    // Get the field name
    var quantity = parseInt($(this).parent().parent().find('.quantity').val());
    
    // If is not undefined
  
        // Increment
        if(quantity>0){
            $(this).parent().parent().find('.quantity').val(quantity - 1);
        }
});
});


});


