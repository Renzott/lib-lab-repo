import styles from '../css/login.module.css'
import Layout from '../component/Layout'
import FormLogin from '../component/FormLogin'

const Index = () => (
    <Layout index={true}>
        <div className={styles["backgroud-image"]}/>
        <div className={`modal-dialog text-center ${styles["container"]}`}>
            <div className={`col-sm-8 ${styles["modal-section"]}`}>
                <div className="modal-content">
                    <div className="col-12 img-login">
                        <img src="https://i.imgur.com/rqyck4A.png" />
                    </div>
                    <FormLogin />
                </div>
            </div>

        </div>
    </Layout>

);

export default Index;