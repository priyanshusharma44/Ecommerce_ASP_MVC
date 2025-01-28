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
            { data: 'category.name', title: 'Category' }
        ],
        "responsive": true,
        "autoWidth": false,
        "paging": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "lengthMenu": [5, 10, 20, 50],
        "language": {
            "emptyTable": "No data available in table"
        }
    });
}
