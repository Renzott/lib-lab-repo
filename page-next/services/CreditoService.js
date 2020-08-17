import builder from '../util/https-base'

const { https } = builder("/credito")

const getAll = () => {
    return https.get("/all")
}

const getByEstado = (estado) => {
    return https.get("/estado?estado=" + estado)
}

const setCredito = (credito) => {
    return https.post("/add",credito)
}

const setEstadoCredito = (credito) => {
    return https.post("/estado",credito)
}

const getDetalle = (id) => {
    return https.get("/detalle",id)
}

export default {
    getByEstado,
    getAll,
    setCredito,
    setEstadoCredito,
    getDetalle
}