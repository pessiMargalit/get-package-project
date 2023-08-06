//#region import...
import './App.css';
import { Routes } from 'react-router-dom';
import { Route } from 'react-router-dom';
import { store } from './redux/store';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import { ClientHomePage } from './Client/clientHomePage';
import { DriverHomePage } from './Driver/driverHomePage';
import { HomePage } from './GetPackage/homePage';
import { LoginModel } from './GetPackage/loginModel';
import { ClientPost } from './Client/clientPost';
import { DriverPost } from './Driver/driverPost';
import { SighnIn } from './GetPackage/sighnIn';
import { DrivePost } from './Drive/drivePost';
import { DriveHistoryGetById } from './Drive/driveHistoryGetByDriverId';
import { DriverConfirmPackagePickup } from './Driver/driverConfirmPackagePickup';
import { PackagePost } from './Package/packagePost';
import { ChangeToClientMode } from './Driver/changeToClientMode';
import { PackageHistoryGetByClientId } from './Client/packageHistoryGetByClientId';
import { DriverProfile } from './Driver/driverProfile';
import { ClientProfile } from './Client/clientProfile';
import { ClientPut } from './Client/clientPut';
import { DriverPut } from './Driver/driverPut';
import { ChangeToDriverMode } from './Client/ChangeToDriverMode';
import { About } from './GetPackage/about';
import { ClientSighnUpAsDriver } from './Client/clientSighnUpAsDriver';
//#endregion
function App() {
  return (
    <div className="App">
      <Provider store={store}>
        <BrowserRouter>
          <Routes>

            <Route exact path='/' element={<HomePage />} />
            <Route exact path='/about' element={<About/>} />
            <Route exact path='/sighn-in' element={<SighnIn />} />

            {/* --------------Driver-------------- */}
            <Route exact path='/driver/:userName' element={<DriverHomePage />} />
            <Route exact path='/driver-sighn-up' element={<DriverPost />} />
            <Route exact path='/driver/:userName/add-drive' element={<DrivePost />} />
            <Route exact path='/driver/:userName/drives-history' element={<DriveHistoryGetById />} />
            <Route exact path='/driver/:userName/profile' element={<DriverProfile/>} />
            <Route exact path='/driver/:userName/update-profile' element={<DriverPut/>} />
            <Route exact path='/driver/confirm-package-pickup' element={<DriverConfirmPackagePickup />} />
            <Route exact path='/:userName/client-mode' element={<ChangeToClientMode/>} />

            {/* --------------Client-------------- */}
            <Route exact path='/client/:userName' element={<ClientHomePage />} />
            <Route exact path='/client-sighn-up' element={<ClientPost />} />
            <Route exact path='/client/:userName/add-package' element={<PackagePost />} />
            <Route exact path='/client/:userName/packages-history' element={<PackageHistoryGetByClientId />} />
            <Route exact path='/client/:userName/profile' element={<ClientProfile/>} />
            <Route exact path='/client/:userName/update-profile' element={<ClientPut/>} />
            <Route exact path='/driver-mode' element={<ChangeToDriverMode/>} />
            <Route exact path='/sighn-up-as-driver' element={<ClientSighnUpAsDriver />} />


            <Route exact path='/login' element={<LoginModel />} />


          </Routes>
        </BrowserRouter>
      </Provider>
    </div>
  );
}

export default App;
