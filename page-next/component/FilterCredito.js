import { useState } from 'react'

const FilterCredito = (props) => {

    const [selectedOption, setSelectedOption] = useState(0);

    const handleChange = (e) => {
        const {value} = e.target;
        setSelectedOption(value);
        props.changeIndex(value)
        props.updateTable(value);
    }

    return (
        <div className="list-group-item d-flex flex-row-reverse align-items-center">
            <div className="col-auto">
                <select className="custom-select mr-sm-2" 
                    value={selectedOption}
                    onChange={handleChange}
                    >
                    <option value="0">Pendientes</option>
                    <option value="1">Aceptadas</option>
                    <option value="2">Rechazadas</option>
                    <option value="3">Archivadas</option>
                </select>
            </div>
            <div className="col-1 font-weight-bold">
                <span className="mr-sm-2">Filtro</span>
            </div>
        </div>

    )
};

export default FilterCredito;  