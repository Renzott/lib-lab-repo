import { useState, useEffect } from 'react'

import ClienteService from "../services/ClienteService"
import CreditoService from "../services/CreditoService"

import styles from '../css/cardItem.module.css'

const CardItemList = (props) => {

    const [cliente, setCliente] = useState({});
    const [credito, setCredito] = useState({ cantidad: 0 })

    useEffect(() => {
        detailClient()
    }, [])

    const detailClient = () => {
        var uuid = props.credito.clientID;
        ClienteService.getByUUID({ uuid }).then(res => {
            setCliente(res.data);

            //fixed cantidad
            var temporalCredito = props.credito;

            setCredito(temporalCredito)
        })
            .catch(console.log)
    }

    const abrirModal = () => {
        props.setDataModal({
            dni: cliente.dni,
            status: true,
        })
    }
    

    // 1 aceptado, 2 rechazado ,3 archivado
    const handleOptions = (e) => {
        var operationId = e.target.dataset.operation
        var changeCredito = props.credito;
        changeCredito.estado = parseInt(operationId)
        CreditoService.setEstadoCredito(changeCredito)
        props.refreshTable(credito.estado)
    }

    /**
     * 
     * @param {Number} number 
     */
    const handleFixed = (number) => {
        return (number.toFixed(2))
    }
    return (
        <li className="list-group-item d-flex justify-content-between align-items-center">
            <div className="col-8 row">
                <img src="https://img.icons8.com/bubbles/2x/user.png" width="60px" className="px-2" />
                <div className="col-3">
                    {cliente.name} {cliente.lastName}
                </div>
                <div className="col-2">
                    <span className="font-weight-bold">S./{handleFixed(credito.cantidad)}</span>
                </div>
                <div className="col-2">
                    {cliente.dni}
                </div>

                <div className="mx-3 col-1">
                    <button type="button" className="btn btn-primary py-1" onClick={abrirModal}>Analisis</button>
                </div>
            </div>
            {(props.currentIndex == 0 || props.currentIndex == 3) ?
                <div className="ml-3">
                    <span className={`badge badge-success badge-pill mx-1 ${styles["clicked"]}`} onClick={handleOptions} data-operation="1">Aceptar</span>
                    <span className={`badge badge-danger badge-pill mx-1 ${styles["clicked"]}`} onClick={handleOptions} data-operation="2">Rechazar</span>
                    {props.currentIndex == 3 ?
                        null :
                        <span className={`badge badge-primary badge-pill ${styles["clicked"]}`} onClick={handleOptions} data-operation="3">Archivar</span>}
                </div>
                :
                null
            }
        </li>
    )
}

export default CardItemList;