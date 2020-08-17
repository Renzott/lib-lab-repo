class Prices extends React.Component {

    state = {
        currency: 'USD'
    }

    render() {

        const { bpi } = this.props;

        const currentList = Object.values(bpi)
        .filter(current => current.code === this.state.currency)
        .map(current => {
            return (
                <li className="list-group-item" key={current.code}>
                    Bitcoin rate for {current.description}
                        : <span className="badge badge-primary">
                        {current.code}
                    </span>
                    <strong>
                        {current.rate} 
                    </strong>
                </li>
            )
        })

        return (
            <div>
                <ul className="list-group">
                    {currentList}
                </ul>
                <br/>
                <select onChange={e => this.setState({currency: e.target.value})} className="form-control">
                    <option value="USD">USD</option>
                    <option value="GBP">GBP</option>
                    <option value="EUR">EUR</option>
                </select>
            </div>);
    }

}

export default Prices