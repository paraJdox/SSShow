// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(() => {
    /*==================
      Modal Operations
    ==================*/
    $('button[data-bs-toggle="modal"]').click(function () {
        let newModal = $('#modal-area');
        let url = $(this).data('url');
        let decodedUrl = decodeURIComponent(url);

        // ajax get request
        $.get(decodedUrl).done((data) => {
            newModal.html(data);
            newModal.find('.modal').modal('show');
        });
    });
});