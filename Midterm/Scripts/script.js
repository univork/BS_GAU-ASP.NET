const AjaxDelete = (url, id) => {
    $.ajax({
        type: "DELETE",
        url: url,
        data: JSON.stringify({ id: id }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            location.reload();
        }
    });
}


const DeleteTodo = (target) => {
    const id = target.dataset.id;
    AjaxDelete("Home/Delete", id); 
}


const DeleteNote = (target) => {
    const noteId = target.dataset.noteid; 
    const todoId = target.dataset.todoid; 
    AjaxDelete(`/Todo/${todoId}/Note/Delete`, noteId); 
}


const EditTodo = (target) => {
    const id = target.dataset.id;
    const new_title = $("#title").val();
    const new_description = $("#description").val();

    $.ajax({
        type: "PUT",
        url: "/Home/Edit/"+id,
        data: JSON.stringify({ title: new_title, description: new_description }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            location.reload();
        }
    });
}


const ToggleStatus = (target) => {
    const id = target.dataset.id;
    $.ajax({
        type: "PUT",
        url: "/Home/Toggle",
        data: JSON.stringify({ id: id }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            location.reload();
        }
    });
}


const InsertNoteInUI = (note) => {
    const noteContainer = document.querySelector(".note-container");
    const noteHTML = `
        <div class="col mb-4">
            <div class="card text-white bg-info mb-3" style="width: 100%; height: 100%;">
                <div class="card-header">Note </div>
                <div class="card-body">
                    <p class="card-text">${note.TextContent}</p>
                </div>
                <button class="btn btn-danger" data-todoid="${note.TodoId}" data-noteid="${note.Id}" onclick="DeleteNote(this)">Delete</button>
            </div>
        </div>
    `
    noteContainer.insertAdjacentHTML("beforeend", noteHTML);
}


const AddNote = (e) => {
    e.preventDefault();

    const text = $("#note-content").val();
    const todoId = $("#todo-id").val();

    $.ajax({
        type: "POST",
        url: `/Todo/${todoId}/Note/Create`,
        data: JSON.stringify({
            TextContent: text,
        }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            console.log(data)
            InsertNoteInUI(data);
        }

    })
}


/* -------------------- BOOTSTRAP -------------------- */
const exampleModal = document.getElementById('exampleModal')
if (exampleModal !== null) {
    exampleModal.addEventListener('show.bs.modal', function (event) {
        const button = event.relatedTarget;

        const id = button.getAttribute('data-bs-id');
        const title = button.getAttribute('data-bs-title');
        const description = button.getAttribute('data-bs-description');

        const modalTitleInput = exampleModal.querySelector('.modal-body input');
        const modalDescInput = exampleModal.querySelector('.modal-body textarea');
        const modalButton = exampleModal.querySelector(".modal-footer button");

        modalTitleInput.value = title;
        modalDescInput.value = description;
        modalButton.dataset.id = id;
    })
}
