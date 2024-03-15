const DATA_COUNT = 12;
const NUMBER_CFG = { count: DATA_COUNT, min: -100, max: 100 };

// Yardýmcý fonksiyonlar
const Utils = {
    months: ({ count }) => {
        const months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December' 
        ];
        return months.slice(0, count);
    },
    numbers: ({ count, min, max }) => {
        const data = [];
        for (let i = 0; i < count; ++i) {
            data.push(Math.random() * (max - min) + min);
        }
        return data;
    },
    transparentize: (color, opacity) => {
        const alpha = opacity === undefined ? 0.5 : 1 - opacity;
        return Chart.helpers.color(color).alpha(alpha).rgbString();
    },
    CHART_COLORS: {
        red: 'rgb(255, 99, 132)',
        blue: 'rgb(54, 162, 235)',
    }
};

// Veri oluþturma
const labels = Utils.months({ count: DATA_COUNT });
const data = {
    labels: labels,
    datasets: [
        {
            label: 'AYLIK NET KAZANC',
            data: Utils.numbers(NUMBER_CFG),
            borderColor: Utils.CHART_COLORS.red,
            backgroundColor: Utils.transparentize(Utils.CHART_COLORS.red, 0.5),
            order: 1
        },
        {
            label: 'YILLIK KAZANC EGRISI',
            data: Utils.numbers(NUMBER_CFG),
            borderColor: Utils.CHART_COLORS.blue,
            backgroundColor: Utils.transparentize(Utils.CHART_COLORS.blue, 0.5),
            type: 'line',
            order: 0
        }
    ]
};

// Grafik yapýlandýrmasý
const config = {
    type: 'bar',
    data: data,
    options: {
        responsive: true,
        plugins: {
            legend: {
                position: 'top',
            },
        }
    },
};

// Grafik oluþturma
const ctx = document.getElementById('line-bar').getContext('2d');
const myChart = new Chart(ctx, config);
