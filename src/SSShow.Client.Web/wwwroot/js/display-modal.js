$(document).ready(() => {
    $('button[data-toggle="modal"]').click(function () {
        createModalContainer();
        displayModalInModalContainer(this, $('#modal-container'));
    });

    function createModalContainer() {
        // modal container creation (we display the modal in this container)
        let modalContainer = document.createElement("div");
        modalContainer.id = "modal-container";

        // add the modal's container (ONCE) in the <main> page's content so we can "select" it
        if ($('#modal-container').length <= 0) {
            let mainPageContent = $('main');
            mainPageContent.prepend(modalContainer);
        }
    }

    function displayModalInModalContainer(modalToggleButton, modalContainer) {
        let url = $(modalToggleButton).data('url');
        let decodedUrl = decodeURIComponent(url);

        // ajax get request to show the modal IN its container
        $.get(decodedUrl).done((data) => {
            modalContainer.html(data);
            modalContainer.find('.modal').modal('show');
        });
    }
});

