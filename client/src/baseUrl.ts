const isProduction = import.meta.env.PROD;

const prod = 'https://windmill-inspection-center-backend.fly.dev'
const dev = 'http://localhost:8080'

export const finalUrl = isProduction ? prod : dev