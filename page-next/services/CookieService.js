import { parseCookies, setCookie } from 'nookies'

const setCookies = (name,value) => {
    setCookie(null, name, value, {
        maxAge: 10800,
        path: '/',
      })
}

const getCookies = () => {

    var cookies = parseCookies();
    return cookies
}

export default {
    getCookies,
    setCookies
}