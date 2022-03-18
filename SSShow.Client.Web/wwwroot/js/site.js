// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(() => {
    /*==================
      MODAL OPERATIONS
    ==================*/
    $('button[data-toggle="modal"]').click(function () {
        // modal area creation (we display the modal in this area)
        let modalArea = document.createElement("div");
        modalArea.id = "modal-area";

        // add the modal (ONCE) in the <main> page content so we can "select" it
        if ($('#modal-area').length <= 0) {
            let mainPageContent = $('main');
            mainPageContent.prepend(modalArea);
        }

        // select the modal area
        let newModal = $('#modal-area');

        /*= DISPLAY MODAL =*/
        let url = $(this).data('url');
        let decodedUrl = decodeURIComponent(url);

        // ajax get request
        $.get(decodedUrl).done((data) => {
            newModal.html(data);
            newModal.find('.modal').modal('show');
        });
    });

});