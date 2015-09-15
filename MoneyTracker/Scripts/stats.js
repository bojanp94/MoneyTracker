$(function () {
    SpendingsByMonthChart();
    SpendingsByCategoryChart();
    SpendingsByDayOfWeekChart();
    SpendingsByDayOfYearChart();
    InitStatsDropdown();
});

function SpendingsByMonthChart() {
    var monthsNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novermber", "December"];
    var months = [];

    $('.month-val').each(function () {
        var val = $(this).text();
        months.push(val);
    });

    MakeChart(monthsNames, months, "#spendingsByMonthChart");
}

function SpendingsByCategoryChart() {
    var categories = [];
    var categoryVals = [];

    $('.category').each(function () {
        var category = $(this).text();
        categories.push(category);
    });

    $('.category-val').each(function () {
        var val = $(this).text();
        categoryVals.push(val);
    });

    MakeChart(categories, categoryVals, "#spendingsByCategoryChart");
}

function SpendingsByDayOfWeekChart() {
    var days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
    var daysVals = [];
    
    $('.day-of-week-val').each(function () {
        var val = $(this).text();
        daysVals.push(val);
    });

    MakeChart(days, daysVals, "#spendingsByDayOfWeekChart");
}

function SpendingsByDayOfYearChart() {
    var days = [];
    for (var i = 0; i < 366; i++) {
        days.push(i + 1);
    }
    var daysVals = [];

    $('.day-of-year-val').each(function () {
        var val = $(this).text();
        daysVals.push(val);
    });

    MakeChart(days, daysVals, "#spendingsByDayOfYearChart");
}

function MakeChart(names, values, divId) {
    var data = {
        labels: names,
        datasets: [{
            label: "My First dataset",
            fillColor: "#60a917",
            strokeColor: "rgba(50,50,50,0.8)",
            highlightFill: "rgba(50,50,50,0.75)",
            highlightStroke: "rgba(50,50,50,1)",
            data: values
        }]
    };

    console.log(data);

    var ctx = $(divId).get(0).getContext("2d");
    var chart = new Chart(ctx).Bar(data);
}

function InitStatsDropdown() {
    $('#stats-dd').on('change', function () {
        var picked = parseInt($(this).val())-1;
        $('.stats-grid > .row').each(function () {
            $(this).hide();
        });
                    
        $('.stats-grid').find('.row:eq(' + picked + ')').show();
    })
    $('#stats-dd').change();
}