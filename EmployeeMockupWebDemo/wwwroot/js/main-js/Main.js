$(document).ready(function () {
    initDataTable();
});

var EmployeesSelected = [];

function initDataTable() {
    dataTable = $('#table_Employee').DataTable({
        "ajax": {
            "url": "/Employees/GetAll",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            {
                "data": null, "render": function (data) {
                    return data.firstName+" "+data.lastname
                }
            },
            { "data": "email" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div>
                            <a href='/Employees/Edit/${data}' class='btn btn-dark' style='cursor:pointer;'  data-toggle="tooltip" title="Edit">
                            <i class='fas fa-edit'></i> 
                            </a>
                            &nbsp;
                            <a onclick=Delete("/Employees/Delete/${data}") class='btn btn-dark text-white' style='cursor:pointer;'  data-toggle="tooltip" title="Delete">
                            <i class="far fa-trash-alt"></i>
                            </a>
                        </div>
                            `;
                    }
                },
        ],
        
        "sScrollX": "100%",
        "sScrollXInner": "100%",
        "bScrollCollapse": true,
        "width": "100%"

    });

    $('#table_Employee tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });

    $('#btnDelRow').click(function () {
        if (EmployeesSelected.length > 0) {
            EmployeesSelected = [];
        }
        for (var i = 0; i < dataTable.rows('.selected').data().length; i++) {
            EmployeesSelected.push(dataTable.rows('.selected').data()[i]["id"]);
        }
        console.log(EmployeesSelected);
        RowsToDelete(EmployeesSelected);
    });
}

function Delete(url) {
    $.ajax({
        type: 'DELETE',
        url: url,
        success: function (data) {
            if (data.success) {
                dataTable.ajax.reload();
            }
        }

    });
}

function RowsToDelete(employeeSelected) {

    $.ajax({
        type: 'POST',
        url: '/Employees/RowsToDelete',
        data: { Employees: JSON.stringify(employeeSelected)},
        success: function (data) {
            if (data.success) {
                dataTable.ajax.reload();
            }
        }
    });

}