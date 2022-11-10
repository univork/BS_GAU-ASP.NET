const DeleteTodo = (target) => {
    const id = target.dataset.id; 
    console.log(id);

    $.ajax({
        type: "DELETE",
        url: 'Home/Delete',
        data: JSON.stringify({ id: id }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            location.reload();
        }
    });
}