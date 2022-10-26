function addAuthor(authorId) {
    var ul = document.getElementById("group-author");

    ul.innerHTML += '<li id="author-' + authorId + '" class="list-group-item"><div class="container"><h5 class="title">Author</h5><button id="remove" class="btn btn-danger float-end" type="button" onclick="return removeAuthor(' + authorId + ')"><i class="fa-solid fa-x"></i></button><button id="hide" class="btn btn-primary me-2 float-end" type="button" onclick="hideAuthor()"><i class="fa-solid fa-eye-slash"></i></button><div class="clearfix"></div><div class="row"><div class="col-md-12 col-lg-4 form-field"><input type="text" name="FirstName" class="form-control form-input" placeholder=" "><label class="form-label" for="FirstName">First Name</label></div><div class="col-md-12 col-lg-4 form-field"><input type="text" name="LastName" class="form-control form-input" placeholder=" "><label class="form-label" for="LastName">Last Name</label></div><div class="col-md-12 col-lg-4 form-field"><input type="date" name="DateOfBirth" class="form-control form-input" placeholder=" "><label class="form-label" for="DateOfBirth">Date of birth</label></div><div class="col-md-12 col-lg-4 form-field"><input type="text" name="CountryOfResidence" class="form-control form-input" placeholder=" "><label class="form-label" for="CountryOfResidence">Country Of Residence</label></div><div class="col-md-12 col-lg-4 form-field"><input type="text" name="Keyword" class="form-control form-input" placeholder=" "><label class="form-label" for="Keyword">Keyword</label></div><div class="col-md-12 col-lg-4 form-field"><input type="text" name="Description" class="form-control form-input" placeholder=" "><label class="form-label" for="Description">Description</label></div></div></div><div class="container mt-2 mb-2"><button id="add" class="btn btn-primary" type="button" onclick="addAuthor()"><i class="fa-solid fa-plus"></i></button></div></li>';
}
function removeAuthor(authorId) {
    var ul = document.getElementById("group-author");
    var count = document.getElementById("group-author").getElementsByTagName("li").length;
    if (count > 1) {
        row.removeChild(document.getElementById('author-' + authorId + ''));
        return true;
    } else {
        Swal.fire('Bạn không thể tiếp tục xóa nữa', '', 'error')
        return false;
    }
}
function addTag() {
    var count = document.getElementById("group-tag").getElementsByTagName("li").length;
    var row = document.getElementById("row-tag");

    row.innerHTML += '<li id="tag-' + count + '" class="list-group-item col-md-6 col-sm-12"><div class="container"><h5 class="title">Tag</h5><button id="remove" class="btn btn-danger float-end" type="button" onclick="return removeTag(' + count + ')"><i class="fa-solid fa-x"></i></button><button id="hide" class="btn btn-primary me-2 float-end" type="button" onclick="hideTag()"><i class="fa-solid fa-eye-slash"></i></button><div class="clearfix"></div><div class="row"><div class="col-md-12 col-lg-4 form-field"><input type="text" name="TagName" class="form-control form-input" placeholder=" "><label class="form-label" for="TagName">Tag Name</label></div><div class="col-md-12 col-lg-4 form-field"><input type="text" name="Keyword" class="form-control form-input" placeholder=" "><label class="form-label" for="Keyword">Keyword</label></div><div class="col-md-12 col-lg-4 form-field"><input type="text" name="Description" class="form-control form-input" placeholder=" "><label class="form-label" for="Description">Description</label></div><div class="col-md-12form-field"><select class="form-select" aria-label="Default select example"><option selected>Chọn menu</option><option value="1">One</option><option value="2">Two</option><option value="3">Three</option></select></div></div></div><div class="container mt-2 mb-2"><button id="add" class="btn btn-primary" type="button" onclick="addTag()"><i class="fa-solid fa-plus"></i></button></div></li>';
}
function removeTag(authorId) {
    var count = document.getElementById("group-tag").getElementsByTagName("li").length;
    var row = document.getElementById("row-tag");
    if (count > 1) {
        row.removeChild(document.getElementById('tag-' + authorId + ''));
        return true;
    } else {
        Swal.fire('Bạn không thể tiếp tục xóa nữa', '', 'error')
        return false;
    }
}

function showTag() {
    document.getElementById("group-tag").style.display = 'block';
    document.getElementById("tag-show").style.display = 'none';
}

function showAuthor() {
    document.getElementById("group-author").style.display = "block";
    document.getElementById("author-show").style.display = "none";
}

function hideTag() {
    debugger;
    document.getElementById("group-tag").style.display = "none";
    document.getElementById("tag-show").style.display = "block";
}

function hideAuthor() {
    document.getElementById("group-author").style.display = "none";
    document.getElementById("author-show").style.display = "block";
}