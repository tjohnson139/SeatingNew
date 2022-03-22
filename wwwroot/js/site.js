// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Refresh tables at intervals

function RefreshDropDownsPartial() {
    $.ajax({
        success: function () {
            $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
            $(" .dthRefresh ").load(window.location.href + " .dthRefresh ");
            $(" .breakRefresh ").load(window.location.href + " .breakRefresh ");
            $(" .lunchRefresh ").load(window.location.href + " .lunchRefresh ");
            $(" .audioAlert ").load(window.location.href + " .audioAlert ");
        },
        error: function () {

        }
    });
}

window.setInterval(function () {
    RefreshDropDownsPartial();
}, 4000);

/////////////Alert Toggle Switch///////////////
$('#bluetooth').change(function () {
    if (this.checked) {
        $('#container *').prop('disabled', true);
    }
    else {
        $('#container *').prop('disabled', false);
    }
});

////////////////////Dth Section////////////////////////

//Dth Off the floor
$(document).on("click", ".dthSent", function () {
    $.ajax({
        type: "Post",
        url: "/Home/empSentDth",
        dataType: 'json',
        data: { "Id": $(this).closest("tr").find(".hiddenDthID").val() },
        success: function () {
            RefreshDropDownsPartial();
        },
    });
});

//DTH Removal
$(document).on("click", ".empNameDth", function () {
    Swal.fire({
        title: 'Are you sure?',
        text: "Remove from the DTH list?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "Post",
                url: "/Home/DeleteDth",
                dataType: 'json',
                data: { "Id": $(this).closest("tr").find(".hiddenDthID").val() },
                success: function (data) {

                    if (data.success == true) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Successfully Removed!',
                            showConfirmButton: false,
                            timer: 0850,

                        })
                        RefreshDropDownsPartial();
                    }
                    else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Failure!',
                            showConfirmButton: false,
                            timer: 2000,
                        })
                    }
                },
                error: function () {
                    alert("Something went wrong.");
                }
            });
        };
    });
});


////////////////////Break Section////////////////////////

//Break Off the floor
$(document).on("click", ".BreakSent", function () {
    $.ajax({
        type: "Post",
        url: "/Home/empSentBreak",
        dataType: 'json',
        data: { "Id": $(this).closest("tr").find(".hiddenBreakID").val() },
        success: function () {
            RefreshDropDownsPartial();
        },
    });
});

//Break Removal
$(document).on("click", ".empNameBreak", function () {
    Swal.fire({
        title: 'Are you sure?',
        text: "Remove from the Break list?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "Post",
                url: "/Home/DeleteBreak",
                dataType: 'json',
                data: { "Id": $(this).closest("tr").find(".hiddenBreakID").val() },
                success: function (data) {

                    if (data.success == true) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Successfully Removed!',
                            showConfirmButton: false,
                            timer: 0850,

                        })
                        RefreshDropDownsPartial();
                    }
                    else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Failure!',
                            showConfirmButton: false,
                            timer: 2000,
                        })
                    }
                },
                error: function () {
                    alert("Something went wrong.");
                }
            });
        };
    });
});



////////////////////Lunch Section////////////////////////

//Lunch Off the floor
$(document).on("click", ".lunchSent", function () {
    $.ajax({
        type: "Post",
        url: "/Home/empSentLunch",
        dataType: 'json',
        data: { "Id": $(this).closest("tr").find(".hiddenLunchID").val() },
        success: function () {
            RefreshDropDownsPartial();
        },
    });
});

//Break Removal
$(document).on("click", ".empNameLunch", function () {
    Swal.fire({
        title: 'Are you sure?',
        text: "Remove from the Lunch list?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "Post",
                url: "/Home/DeleteLunch",
                dataType: 'json',
                data: { "Id": $(this).closest("tr").find(".hiddenLunchID").val() },
                success: function (data) {

                    if (data.success == true) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Successfully Removed!',
                            showConfirmButton: false,
                            timer: 0850,

                        })
                        RefreshDropDownsPartial();
                    }
                    else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Failure!',
                            showConfirmButton: false,
                            timer: 2000,
                        })
                    }
                },
                error: function () {
                    alert("Something went wrong.");
                }
            });
        };
    });
});