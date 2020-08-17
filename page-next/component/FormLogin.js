import { useState } from 'react'
import { useRouter } from 'next/router'
import UsuarioService from '../services/UsuarioService'
import CookieService from '../services/CookieService'

const FormLogin = () => {

    const router = useRouter();

    const formData = {
            mail: '',
            password: ''
    }

    const [form,setForm] = useState(formData);

    const handleSubmit = (e) =>{
        e.preventDefault();
       UsuarioService.setLoginGetToken(form).then(res => {
           if(res.status == 200){
                CookieService.setCookies('token',res.data)
                router.push("/creditos")
            }
        }).catch(console.log)
    }

    const handleInputChange = (e) => {
        const {name,value} = event.target;
        setForm({...form,[name]: value});
    }

    return (
        <form className="col-12 mb-3" onSubmit={handleSubmit}>
            <div className="form-group">
                <input type="text" 
                        className="form-control" 
                        placeholder="Correo de Usuario"
                        name="mail"
                        value={form.mail}
                        onChange={handleInputChange}
                        id="mail"/>
            </div>
            <div className="form-group">
                <input type="password" 
                        className="form-control" 
                        placeholder="Correo de Usuario" 
                        name="password"
                        value={form.pwd}
                        onChange={handleInputChange}
                        id="password"/>
            </div>
            <button type="submit" className="btn btn-primary">Primary</button>
            
        </form>
    )
}

export default FormLogin;