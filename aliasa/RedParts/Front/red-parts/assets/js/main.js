
let filterHead=document.querySelectorAll('.filter-box .box-head')
let filterUp=document.querySelectorAll('.up-ico')
let filterList=document.querySelectorAll('.box-main')

for(let i=0;i<filterUp.length;i++){
    filterHead[i].onclick=()=>{
        filterUp[i].classList.toggle('active')
        filterList[i].classList.toggle('active')
    } 
}



 
let menuIco=document.querySelectorAll('.open-ico')
let menuHeader=document.querySelectorAll('.menu-header')
let closeIco=document.querySelectorAll('.close-ico')

for(let i=0;i<menuHeader.length;i++){
    menuIco[i].onclick=function(){
        menuHeader[i].classList.add('active')
        menuIco[i].classList.add('active')
        closeIco[i].classList.add('active')
    }

    closeIco[i].onclick=function(){
        menuHeader[i].classList.remove('active')
        menuIco[i].classList.remove('active')
        closeIco[i].classList.remove('active')
    }


}