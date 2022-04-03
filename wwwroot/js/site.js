// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

///Variable related to alert sounds
var alertOn = true;

////Alert sounds off and on with switch
$(document).ready(function () {
    $(" #bluetooth ").data('notenabled', false);//enabled assumption
    $(" #bluetooth ").click(function () {
        var currentState = $(this).data('notenabled');
        console.log(currentState)
        if (currentState) {
            alertOn = true;
        } else {
            alertOn = false;
        }
        $(this).data('notenabled', !currentState);
    });
});


//Refresh tables at intervals
function RefreshDropDownsPartial() {
    $.ajax({
        success: function () {
            $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
            $(" .dthRefresh ").load(window.location.href + " .dthRefresh ");
            $(" .breakRefresh ").load(window.location.href + " .breakRefresh ");
            $(" .lunchRefresh ").load(window.location.href + " .lunchRefresh ");
            if (alertOn) {
                $(" #AlertSound ").load(window.location.href + " #AlertSound ");
            }
        },
        error: function () {

        }
    });
}

window.setInterval(function () {
    RefreshDropDownsPartial();
}, 4000);

////////////////////Dth Section////////////////////////

//Add Dth
$(document).on("click", "#dth_submit", function (e) {
    e.preventDefault();
    var EmployeeId = Number($("#EmpId").val());
    var EmpPosition = Number($("#EmployeePosition").val());
    var json = {
        EmployeeId: EmployeeId,
        EmpPosition: EmpPosition
    };
    console.log("Model", json);
    $.ajax({
        type: "post",
        url: "/Home/CreateDth",
        dataType: "json",
        data: { "json": JSON.stringify(json) },
        success: function (data) {
            if (data.success) {
                $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");                
                $(" #DropDownsPartialDiv ").load(window.location.href + " #DropDownsPartialDiv ");
            }
            else
                alert("Error: Please enter your name AND position");
        },
        error: function () {
            alert("Error: Please enter your name AND position");
        }
    });
});

//Dth Off the floor
$(document).on("click", ".dthSent", function () {
    $.ajax({
        type: "Post",
        url: "/Home/empSentDth",
        dataType: 'json',
        data: { "Id": $(this).closest("tr").find(".hiddenDthID").val() },
        success: function () {
            $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
            $(" #DropDownsPartialDiv ").load(window.location.href + " #DropDownsPartialDiv ");
        },
    });
});

// Dth Back on the floor
$(document).on("click", ".cancelDthSent", function () {
    Swal.fire({
        title: 'Are you sure?',
        text: "Put back on the floor without removing from the list?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "Post",
                url: "/Home/cancelDthSent",
                dataType: 'json',
                data: { "Id": $(this).closest("tr").find(".hiddenDthID").val() },
                success: function (data) {

                    if (data.success == true) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Back on the list!',
                            showConfirmButton: false,
                            timer: 0850,

                        })
                        $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
                        $(" #DropDownsPartialDiv ").load(window.location.href + " #DropDownsPartialDiv ");
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
        }
    })
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
                        $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
                        $(" #DropDownsPartialDiv ").load(window.location.href + " #DropDownsPartialDiv ");
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

//Add Break
$(document).on("click", "#break_submit", function (e) {
    event.preventDefault();
    var EmployeeId = Number($("#EmpIdBreak").val());
    var EmpPosition = Number($("#EmployeePositionBreak").val());
    var json = {
        EmployeeId: EmployeeId,
        EmpPosition: EmpPosition
    };
    console.log("Model", json);
    $.ajax({
        type: "post",
        url: "/Home/CreateBreak",
        dataType: "json",
        data: { "json": JSON.stringify(json) },
        success: function (data) {
            if (data.success) {
                $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
                $(" #DropDownsPartialDiv ").load(window.location.href + " #DropDownsPartialDiv ");
            }
            else
                alert("Error: Please enter your name AND position");
        },
        error: function () {
            alert("Error: Please enter your name AND position");
        }
    });
});

//Break Off the floor
$(document).on("click", ".BreakSent", function () {
    $.ajax({
        type: "Post",
        url: "/Home/empSentBreak",
        dataType: 'json',
        data: { "Id": $(this).closest("tr").find(".hiddenBreakID").val() },
        success: function () {
            $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
            $(" #DropDownsPartialDiv ").load(window.location.href + " #DropDownsPartialDiv ");
        },
    });
});

// Break Back on the floor
$(document).on("click", ".cancelBreakSent", function () {
    Swal.fire({
        title: 'Are you sure?',
        text: "Put back on the floor without removing from the list?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "Post",
                url: "/Home/cancelBreakSent",
                dataType: 'json',
                data: { "Id": $(this).closest("tr").find(".hiddenBreakID").val() },
                success: function (data) {

                    if (data.success == true) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Back on the list!',
                            showConfirmButton: false,
                            timer: 0850,

                        })
                        $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
                        $(" #DropDownsPartialDiv ").load(window.location.href + " #DropDownsPartialDiv ");
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
        }
    })
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
                        $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
                        $(" #DropDownsPartialDiv ").load(window.location.href + " #DropDownsPartialDiv ");
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

//Create Lunch Main Page
$(document).on("click", "#lunch_submit", function (e) {
    e.preventDefault();
    var EmployeeId = Number($("#EmpIdLunch").val());
    var EmpPosition = Number($("#EmployeePositionLunch").val());
    var LunchTime = $("#lunchStartTime").val();
    var LongerLunch = $('.lunch_45:checkbox:checked').val();
    var json = {
        EmployeeId: EmployeeId,
        EmpPosition: EmpPosition,
        LunchTime: LunchTime,
        LongerLunch: LongerLunch
    };
    console.log("Model", json);
    $.ajax({
        type: "post",
        url: "/Home/CreateLunch",
        dataType: "json",
        data: { "json": JSON.stringify(json) },
        success: function (data) {
            if (data.success) {
                $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
                $(" #DropDownsPartialDiv ").load(window.location.href + " #DropDownsPartialDiv ");
            }
        },
        error: function () {
            Swal.fire({
                title: 'LUNCH NOT SUBMITTED',
                imageUrl: 'https://media1.razorplanet.com/share/512056-7346/siteImages/Text%20Msg%20Images/no-lunch.jpg',
                imageWidth: 500,
                imageHeight: 500,
                imageAlt: 'Custom image',
                background: '#FF0000',
                width: 1200,
                backdrop: '#FF0000',
                color: '#f7f7f7',
            })
        }
    });
});

//Create Lunch - Lunch Page
$(document).on("click", "#lunch_submit_main", function (e) {
    e.preventDefault();
    var EmployeeId = Number($("#EmpIdMainLunch").val());
    var EmpPosition = Number($("#EmployeeMainPositionLunch").val());
    var LunchTime = $("#lunchMainStartTime").val();
    var LongerLunch = $('.lunch_main_45:checkbox:checked').val();
    var json = {
        EmployeeId: EmployeeId,
        EmpPosition: EmpPosition,
        LunchTime: LunchTime,
        LongerLunch: LongerLunch
    };
    console.log("Model", json);
    $.ajax({
        type: "post",
        url: "/Home/CreateLunch",
        dataType: "json",
        data: { "json": JSON.stringify(json) },
        success: function (data) {
            if (data.success) {
                if (data.success == true) {
                    Swal.fire({
                        icon: 'success',
                        title: 'You signed up for lunch!',
                        showConfirmButton: false,
                        timer: 20000,
                    })
                    window.location.href = "/Home/Lunch";
                }
            }
        },
        error: function () {
            Swal.fire({
                title: 'LUNCH NOT SUBMITTED',
                imageUrl: 'https://media1.razorplanet.com/share/512056-7346/siteImages/Text%20Msg%20Images/no-lunch.jpg',
                imageWidth: 500,
                imageHeight: 500,
                imageAlt: 'Custom image',
                background: '#FF0000',
                width: 1200,
                backdrop: '#FF0000',
                color: '#f7f7f7',
            })
        }
    });
});

//Create Override Lunch Page
$(document).on("click", "#override_submit", function (e) {
    e.preventDefault();
    var EmployeeId = Number($("#EmpIdLunch").val());
    var EmpPosition = Number($("#EmployeePositionLunch").val());
    var LunchTime = $("#lunchStartTime").val();
    var LongerLunch = $('.lunch_45:checkbox:checked').val();
    var DblLunch = $('.lunch_dbl:checkbox:checked').val();
    var json = {
        EmployeeId: EmployeeId,
        EmpPosition: EmpPosition,
        LunchTime: LunchTime,
        LongerLunch: LongerLunch,
        DblLunch: DblLunch
    };
    console.log("Model", json);
    $.ajax({
        type: "post",
        url: "/Home/CreateOverrideLunch",
        dataType: "json",
        data: { "json": JSON.stringify(json) },
        success: function (data) {
            if (data.success) {
                Swal.fire({
                    icon: 'success',
                    title: 'You signed up for lunch!',
                    showConfirmButton: false,
                    timer: 20000,
                })
                window.location.href = "/Home/Lunch";
            }
        },
        error: function () {
            Swal.fire({
                title: 'LUNCH NOT SUBMITTED',
                imageUrl: 'https://media1.razorplanet.com/share/512056-7346/siteImages/Text%20Msg%20Images/no-lunch.jpg',
                imageWidth: 500,
                imageHeight: 500,
                imageAlt: 'Custom image',
                background: '#FF0000',
                width: 1200,
                backdrop: '#FF0000',
                color: '#f7f7f7',
            })
        }
    });
});

//Lunch Off the floor
$(document).on("click", ".lunchSent", function () {
    $.ajax({
        type: "Post",
        url: "/Home/empSentLunch",
        dataType: 'json',
        data: { "Id": $(this).closest("tr").find(".hiddenLunchID").val() },
        success: function () {
            $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
            $(" #AlertSound ").load(window.location.href + " #AlertSound ");
            $(" #DropDownsPartialDiv ").load(window.location.href + " #DropDownsPartialDiv ");
        },
    });
});

// Lunch Back on the floor
$(document).on("click", ".cancelLunchSent", function () {
    Swal.fire({
        title: 'Are you sure?',
        text: "Put back on the floor without removing from the list?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "Post",
                url: "/Home/cancelLunchSent",
                dataType: 'json',
                data: { "Id": $(this).closest("tr").find(".hiddenLunchID").val() },
                success: function (data) {

                    if (data.success == true) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Back on the list!',
                            showConfirmButton: false,
                            timer: 0850,

                        })
                        $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
                        $(" #DropDownsPartialDiv ").load(window.location.href + " #DropDownsPartialDiv ");
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
        }
    })
});

//Lunch Removal Home
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
                        $(" #headerRefresh ").load(window.location.href + " #headerRefresh ");
                        $(" #DropDownsPartialDiv ").load(window.location.href + " #DropDownsPartialDiv ");
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

//Lunch Removal Home
$(document).on("click", ".empNameLunchMain", function () {
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
                        window.location.href = "/Home/Lunch";
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