
let filterHead=document.querySelectorAll('.filter-box .box-head')
let filterUp=document.querySelectorAll('.up-ico')
let filterList=document.querySelectorAll('.box-main')

for(let i=0;i<filterUp.length;i++){
    filterHead[i].onclick=()=>{
        filterUp[i].classList.toggle('active')
        filterList[i].classList.toggle('active')
    } 
}

let choose=document.querySelectorAll('.choose-li')
let chooseMain=document.querySelectorAll('.down-choose')



let labelProduct=document.querySelectorAll('.product-label')

for(let i=0;i<labelProduct.length;i++){
    labelProduct[i].onclick=()=>{
        removeActive()
        labelProduct[i].classList.add('active')
    }
}

const removeActive = () => {
   
    for(let i=0;i<labelProduct.length;i++){
        labelProduct[i].classList.remove('active')
    }
 }
 


 let colorProduct=document.querySelectorAll('.color-box')

for(let i=0;i<colorProduct.length;i++){
    colorProduct[i].onclick=()=>{
        removecolorActive()
        colorProduct[i].classList.add('active')
    }
}

const removecolorActive = () => {
   
    for(let i=0;i<colorProduct.length;i++){
        colorProduct[i].classList.remove('active')
    }
 }
 

 
let minus=document.querySelector('.minus')
 let plus=document.querySelector('.plus')
 let count=document.querySelector('.count')





///search
$(document).on("keyup", "#searchinp", function () {
    let inputVal = $(this).val().trim();
    $(".search-list-p li").slice(0).remove();
    $.ajax({
        method: "get",
        url: "home/search?search=" + inputVal,
        success: function (res) {
            $(".search-list-p").append(res);
        }
    });
});

    //end

/// basket start

$(document).on("click", "#addToCart", function () {

    let id = $(this).attr('cart-id');
    let basketCount = $("#basketCount")
    let basketCurrentCount = $("#basketCount").html()
    $.ajax({
        method: "POST",
        url: "/basket/addbasket",
        data: {
            id: id
        },
        content: "application/x-www-from-urlencoded",
        success: function (res) {
            Swal.fire({
                icon: 'success',
                title: 'Product added',
                showConfirmButton: false,
                timer: 1500,
            })
            let scrollBasket = $('#basketCountsc');
            let scrollBasketCount = $(scrollBasket).text();
            scrollBasketCount++;
            $(scrollBasket).text(scrollBasketCount);
            basketCurrentCount++;
            basketCount.html("")
            basketCount.append(basketCurrentCount)
        }


    });

});
// basket end

