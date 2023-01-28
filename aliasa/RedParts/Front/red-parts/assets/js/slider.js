var swiper = new Swiper(".first-slider", {});


var swiper = new Swiper(".featured-slider", {
    slidesPerView:5,
  slidesPerGroup:1,
  spaceBetween:30,
  loop:true,
  autoplay:{
    delay:3000
},
breakpoints:{
  280:{
      slidesPerView:1
      
  },
  
  768:{
     slidesPerView:2
  },
  992:{
      slidesPerView:3
  },
  1200:{
    slidesPerView:5
  }

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
breakpoints:{
  280:{
      slidesPerView:1
      
  },
  
  768:{
     slidesPerView:2
  },
  992:{
      slidesPerView:3
  },
  1200:{
    slidesPerView:5
  }

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
breakpoints:{
  280:{
      slidesPerView:1
      
  },
  
  768:{
     slidesPerView:2
  },
  992:{
      slidesPerView:2
  },
  1200:{
    slidesPerView:4
  }

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

breakpoints:{
  280:{
      slidesPerView:1
      
  },
  
  768:{
     slidesPerView:2
  },
  992:{
      slidesPerView:2
  },
  1200:{
    slidesPerView:4
  }

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
breakpoints:{
  280:{
      slidesPerView:2
      
  },
  
  768:{
     slidesPerView:2
  },
  992:{
      slidesPerView:3
  },
  1200:{
    slidesPerView:5
  }

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