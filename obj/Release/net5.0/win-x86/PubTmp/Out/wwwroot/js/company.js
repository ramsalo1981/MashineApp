var dataTable;

$(document).ready(function () {
    loadDataTable();

});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Swedish.json"
        },
        "ajax": {
            "url": "/Admin/Company/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "streetAddress", "width": "25%%" },
            { "data": "postalCode", "width": "10%%" },
            { "data": "city", "width": "10%%" },
            { "data": "phoneNumber", "width": "15%%" },
            {
                "data": "isAuthorizedCompany",
                "render": function (data) {
                    if (data) {
                        return `<input type="checkbox" disabled checked class="form-check-input"/>`
                    }
                    else {
                        return `<input type="checkbox" disabled class="form-check-input"/>`
                    }
                },
                "width": "20%%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Company/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Admin/Company/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "20%"
            },

        ]
    });
}

function Delete(url) {
    swal({
        title: "Är du säker att du vill radera?",
        text: "Du kommer inte att kunna återställa data!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
        buttons: ['Avbryt', 'Ja']
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
