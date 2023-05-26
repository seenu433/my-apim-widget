import { useEffect, useState } from "react"
import { useRequest, useSecrets, useValues } from "../hooks"

const App = () => {
  const values = useValues()
  const { userId, token, apiVersion, managementApiUrl } = useSecrets()

  const [user, setUser] = useState({ "UserId": "", "FirstName": "", "LastName": "", "Email": "", "State": "", "Groups": [] })

  function onSubmit() {

    const requestHeaders: HeadersInit = new Headers();
    if (token) requestHeaders.set('UserToken', token);
    if (userId) requestHeaders.set('UserId', userId);
    requestHeaders.set('ApiVersion', apiVersion);
    requestHeaders.set('ManagementApiUrl', managementApiUrl);

    fetch(
      `${values.externalApiUri}`,
      {
        method: "POST",
        headers: requestHeaders,
      }
    ).then(e => { return e.json() })
      .then(text => { setUser(text) })
  }

  return (
    <div className="flex-columns-container height-fill">
      <div className="form-group">
        <button onClick={onSubmit} type="submit" className="button button-primary">Submit</button>
      </div>
      <div>User Id : {user.UserId}</div>
      <div>First Name: {user.FirstName}</div>
      <div>Last Name: {user.LastName}</div>
      <div>Email: {user.Email}</div>
      <div>State: {user.State}</div>
    </div>
  )
}

export default App