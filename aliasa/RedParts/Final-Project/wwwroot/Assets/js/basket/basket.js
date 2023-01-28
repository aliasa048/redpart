


$(function () {


    $(document).on('click', '#deleteBtn', function () {
        var id = $(this).data('id')
        var basketCount = $('#basketCount')
        var basketCurrentCount = $('#basketCount').html()
        var id = $(this).data('id');
        var quantity = $(this).data('quantity')
        var sum = basketCurrentCount - quantity
       
        

        $.ajax({
            method: 'POST',
            url: "/basket/delete",
            data: {
                id : id
            },
            success: function (res) {
               
                Swal.fire({
                    icon: 'success',
                    title: 'Product deleted',
                    showConfirmButton: false,
                    timer: 1500
                })
          
                $(`.basket-product[id=${id}]`).remove();
                basketCount.html("")
                basketCount.append(sum)
                location.reload();

              
            }
        })

    })
  
  
  });
  






