module.exports = {
    purge: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
    darkMode: false,
    theme: {
        extend: {
            height: {

                "100px": '100px',
                "140px": '140px',
            },
            width: {
                "100px": '100px',
                "140px": '140px',
            }
        }
    },
    variants: {
        extend: {},
    },
    plugins: [],
}

