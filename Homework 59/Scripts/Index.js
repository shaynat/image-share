$(() => {
    
    $('.col-md-4').mouseover(function () {
        const id = $(this).data('id');
        $(`#like-count-${id}`).css("visibility", "visible");
        $(`#like-${id}`).css("visibility", "visible");
        $(`#img-${id}`).css("opacity", '.7');
    });

    $('.col-md-4').mouseout(function () {
        const id = $(this).data('id');
        $(`#like-count-${id}`).css("visibility", "hidden");
        $(`#like-${id}`).css("visibility", "hidden");
        $(`#img-${id}`).css("opacity", '1');
    });
});