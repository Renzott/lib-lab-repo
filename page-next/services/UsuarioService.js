import builder from '../util/https-base'

const { https } = builder("/user")

const setMailAuth = (mail) => {
    return https.post("/mail",mail)
}

const setLoginGetToken = (user) => {
    return https.post("/login",user)
}

export default {
    setMailAuth,
    setLoginGetToken
}