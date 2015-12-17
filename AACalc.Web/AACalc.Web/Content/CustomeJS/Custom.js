
        $(document).ready(function () {
            $("#State").change(function () {

                debugger

                var StateId = $("#State").val();


                var myUrl = 'Person/GetCityByStateId';
                $.ajax({
                    url: myUrl,
                    type: 'POST',
                    dataType: "json",
                    data: { 'StateId': StateId },
                    success: function (d) {
                        $("#City").find("option").remove();
                        // $("#City").find("option:gt(0)").remove();
                        if (d.length > 0) {
                            for (var i = 0; i < d.length; i++) {
                                $("#City").append($('<option>', {
                                    value: d[i].CityId,
                                    text: d[i].Name
                                }));

                            }
                        }


                    },
                    error: function () {
                        alert('failure');
                    }
                });









            });
        });
