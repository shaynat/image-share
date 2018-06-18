$(() => {

    setInterval(function () {
        const id = $(".view-single").data('id');
        $.get("/Home/GetLikes", { id: id }, function (count) {
            $("#like-count").text(count);
        });
    }, 100);


    $(".view-single").on('click', '#like-button', function () {
        const id = $(this).data('id');
        $.post('/Home/LikeCount', { id: id }, function () {
            window.location.reload();
        });
    });
});