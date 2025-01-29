$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": {
            url: '/admin/product/getall',
            type: 'GET',
            datatype: 'json'
        },
        "columns": [
            { data: 'title', title: 'Title' },
            { data: 'isbn', title: 'ISBN' },
            { data: 'listPrice', title: 'Price' },
            { data: 'author', title: 'Author' },
            { data: 'category.name', title: 'Category' },
            {
                data: 'id',
                "render": function (data) {
                    return `
                    <div class="w-100 btn-group d-flex justify-content-center">
                        <a href="/admin/product/upsert/${data}" class="btn btn-info rounded-1 btn-sm mx-1">
                            <i class="bi bi-pencil-square"></i> Edit
                        </a>
                       <a href="javascript:void(0);" onClick="deleteProduct(${data})" class="btn btn-danger rounded-1 btn-sm mx-1">
                         <i class="bi bi-trash-fill"></i> Delete
                       </a>
                    </div>`;
                }
            }
        ],
        "responsive": true,
        "autoWidth": false,
        "paging": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "lengthMenu": [4, 10, 20, 50],
        "language": {
            "emptyTable": "No data available in table"
        }
    });
}

function deleteProduct(id) {
    // Define the URL for the delete request
    const url = `/admin/product/delete/${id}`;

    // Call the Delete function with the constructed URL
    Delete(url);
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    $('#tblData').DataTable().ajax.reload();
                    toastr.success(data.message);
                }
            });
        }
    });
}
