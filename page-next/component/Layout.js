import Head from 'next/head'
import Navbar from './Navbar';

const Layout = (props) => {
    
    return(
    <div>
        <Head>
            <title>Gestor de Creditos</title>
            <link rel="stylesheet"
            href="https://bootswatch.com/4/lux/bootstrap.min.css"/>
        </Head>
        {props.index ? null:<Navbar /> }
        <div>
            {props.children}
        </div>

    </div>
)}

export default Layout;