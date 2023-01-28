var swiper = new Swiper(".first-slider", {});


var swiper = new Swiper(".featured-slider", {
    slidesPerView:5,
  slidesPerGroup:1,
  spaceBetween:30,
  loop:true,
  autoplay:{
    delay:3000
},
 
    navigation: {
      nextEl: ".next-ico",
      prevEl: ".prev-ico",
    },
  });

  var swiper = new Swiper(".attention-slider", {
    slidesPerView:5,
  slidesPerGroup:1,
  spaceBetween:30,
  loop:true,
  autoplay:{
    delay:3000
},
 
    navigation: {
      nextEl: ".next-ico-att",
      prevEl: ".prev-ico-att",
    },
  });


    var swiper = new Swiper(".arrivals-slider", {
        slidesPerView:4,
  slidesPerGroup:1,
  spaceBetween:30,
  loop:true,
  autoplay:{
    delay:3000
},
        navigation: {
            nextEl: ".next-ico-arr",
            prevEl: ".prev-ico-arr",
          },
    });


    var swiper = new Swiper(".latest-slider", {
        slidesPerView:4,
  slidesPerGroup:1,
  spaceBetween:30,
  loop:true,
  autoplay:{
    delay:3000
},
        navigation: {
            nextEl: ".next-ico-lat",
            prevEl: ".prev-ico-lat",
          },
    });

    var swiper = new Swiper(".pro-slider", {
      slidesPerView:5,
  slidesPerGroup:1,
  spaceBetween:30,
  loop:true,
  autoplay:{
    delay:3000
},
    });



    var swiper = new Swiper(".mySwiper", {
      
      spaceBetween: 20,
      slidesPerView: 4,
      
      freeMode: true,
      watchSlidesProgress: true,
    });
    var swiper2 = new Swiper(".mySwiper2", {
      loop: true,
      spaceBetween: 10,
      navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
      },
      thumbs: {
        swiper: swiper,
      },
    });