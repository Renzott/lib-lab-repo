import ApiService from "../services/ApiService"
import { useState, useEffect } from 'react'

const test = () => {

    useEffect(() => {
        getAllCredits();
    }, [])

    const [creditos, setCreditos] = useState([]);

    const getAllCredits = () =>{
        ApiService.getSbs('85648466')
            .then(res => {
                setCreditos([res.data])
            });
    }
    

    return(
    <div>
        {creditos && creditos.map((credito) => (
                        <p key={credito.dni}>{credito.totalDeuda} {credito.dni}</p>
                    ))}
    </div>)
}


export default test;