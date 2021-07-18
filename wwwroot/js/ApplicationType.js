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
            "url": "/Admin/ApplicationType/GetAll"
        },
        "columns": [
            { "data": "name", "width": "60%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/ApplicationType/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Admin/ApplicationType/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "40%"
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


