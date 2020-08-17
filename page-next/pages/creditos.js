import { useState, useEffect } from 'react'

import styles from '../css/login.module.css'

import Layout from '../component/Layout'
import CardItem from '../component/CardItemList'
import FilterCredito from '../component/FilterCredito'
import AnalisisCredito from '../component/AnalisisCredito'

import CreditoService from "../services/CreditoService"


const Creditos = () => {

    useEffect(() => {
        getAllCredits(0);
    }, [])

    const [creditos, setCreditos] = useState([]);
    const [estadoIndex,setEstadoIndex] = useState(0);

    const dataModal = {
        dni: '0000000',
        status: false
    }

    const [getDataModal,setDataModal] = useState(dataModal);



    const getAllCredits = (index) => {
        CreditoService.getByEstado(index)
            .then(res => {
                setCreditos([...res.data])
            })
            .catch(console.log)
    }

    const refreshTable= (estado) => {
        setCreditos(creditos.filter(credito => credito.estado != estado))
    }

    return (
        <Layout>
            <div className={`text-center ${styles["container"]}`}>
                <FilterCredito changeIndex={setEstadoIndex} updateTable={getAllCredits}/>
                <ul className="list-group">
                    <li className="list-group-item d-flex justify-content-between align-items-center">
                        <div className="col-9 row">
                            <div className="col-1">
                                Foto
                            </div>
                            <div className="col-2">
                                Nombre
                            </div>
                            <div className="col-2">
                                Monto
                            </div>
                            <div className="col-2">
                                DNI
                            </div>
                        </div>
                    </li>
                    {creditos && creditos.map((credito) => (
                        <CardItem key={credito.id} credito={credito} currentIndex={estadoIndex} refreshTable={refreshTable} setDataModal={setDataModal}/>
                    ))}
                </ul>
                <AnalisisCredito showModal={getDataModal} configData={setDataModal}/>
            </div>
        </Layout>
    );
}
export default Creditos