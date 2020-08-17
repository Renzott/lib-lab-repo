import builder from '../util/https-base'

const { https } = builder("/cliente")

const getAll = () => {
    return https.get("/all")
}

const getByUUID = (uuid) => {
    return https.post("/id",uuid)
}

export default {
    getAll,
    getByUUID
}