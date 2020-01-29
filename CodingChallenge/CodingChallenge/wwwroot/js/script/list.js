var list = (function () {
    $(document).ready(function () {
        $('#tableUserProject').DataTable({
            "processing": false,
            "serverSide": true,
            "paging": false,
            "ordering": false,
            "info": false,
            "bFilter": false,
            "ajax": {
                "type": "POST",
                "contentType": "application/json",
                "url": resolveUrl("~/User/GetProjectByUser"),
                "data": function (data) {
                    data.id = parseInt($("#selectUserInformation").val());

                    return JSON.stringify(data);
                }
            },
            "columns": [
                {
                    "orderable": false,
                    "data": "id"
                },
                {
                    "orderable": false,
                    "data": "startDate",
                    "render": function (data, type, row, meta) {
                        return moment(data).format("YYYY-MM-DD");
                    }
                },
                {
                    "orderable": false,
                    "data": "timeToStart",
                    "render": function (data, type, row, meta) {
                        return data < 0 ? "started" : data;
                    }
                },
                {
                    "orderable": false,
                    "data": "endDate",
                    "render": function (data, type, row, meta) {
                        return moment(data).format("YYYY-MM-DD");
                    }
                },
                {
                    "orderable": false,
                    "data": "credits"
                },
                {
                    "orderable": false,
                    "data": "isActive",
                    "render": function (data, type, row, meta) {
                        return data ? "Active" : "Inactive";
                    }
                }
            ],
            "order": [[0, 'asc']]
        });

        $("#btnShowProjectByUser").click(function () {
            reloadTable();
        });
    });

    var reloadTable = function () {
        var $table = $("#tableUserProject");
        var table = $table.DataTable();
        table.ajax.reload(null, true);
    };
}());