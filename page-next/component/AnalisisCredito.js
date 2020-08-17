import { useEffect, useState } from 'react'
import { makeStyles } from '@material-ui/core/styles';
import { Table, TableContainer, TableHead, TableCell, TableBody, TableRow, Modal, Button, TextField } from '@material-ui/core';

import ApiService from "../services/ApiService"

import styles from '../css/modal.module.css'

const AnalisisCredito = (props) => {

    const sbsInicial = {
        "dni": 0,
        "totalDeuda": 0
    }

    const sentinelInicial = {
        "dni": 0,
        "nroDeudas": 0,
        "score": [
            "Bueno",
            0
        ]
    }

    const [detallesSBS, setDetallesSBS] = useState([sbsInicial]);
    const [detallesSenitel, setDetallesSenitel] = useState([sentinelInicial]);
    const [isRendered, SetisRendered] = useState(true);

    const selectModalColor = (score) => {
        console.log(score)
        switch (score) {
            case 'Bueno':
                return 'text-white bg-success'
            case 'Regular':
                return 'text-white bg-warning'
            case 'Malo':
                return 'text-white bg-danger'
            default:
                return 'bg-light'
        }

    }

    const { dni, status } = props.showModal;

    const getDetailsDNI = (dni) => {
        if (isRendered) {
            ApiService.getSentinel(dni)
                .then(async (res) => {
                    await setDetallesSenitel([res.data])
                })
                .catch(console.log)
            ApiService.getSbs(dni)
                .then(res => {
                    SetisRendered(false);
                    setDetallesSBS([res.data])
                })
                .catch(console.log)

        }
    }

    const closeModal = () => {
        props.configData({
            status: false
        });
        SetisRendered(true)
    }

    return (
        <Modal open={status} className={styles["modal"]}>
            <div className="modal-dialog modal-dialog-centered" role="document">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title" id="exampleModalLongTitle">Detalle del Cliente</h5>
                    </div>
                    <div className="modal-body">
                        {(status == false) ? null : getDetailsDNI(dni)}
                        {detallesSBS[0] != null && detallesSBS[0] != 0 ? (
                            <div>
                                <div className={`card ${selectModalColor(detallesSenitel[0].score[0])}`}>
                                    <div className="card-header">
                                        Analisis
                                    </div>
                                    <ul className="list-group list-group-flush">
                                        <li className="list-group-item text-dark">Segun Sentinel, este es un Usuario {detallesSenitel[0].score[0]}</li>
                                        <li className="list-group-item text-dark">Numero de Deudas: {detallesSenitel[0].nroDeudas}</li>
                                        <li className="list-group-item text-dark">Total de Deudas: {detallesSBS[0].totalDeuda}</li>
                                        <li className="list-group-item text-dark">Score del Cliente: {detallesSenitel[0].score[1]}</li>
                                    </ul>
                                </div>
                            </div>
                        ) : "null"}
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-primary" onClick={closeModal}>Salir</button>
                    </div>
                </div>

            </div>

        </Modal>

    )
};

export default AnalisisCredito;  