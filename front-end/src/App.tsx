import React from 'react';
import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import HomePage from './modules/Home/pages/HomePage';
import CreditCard from './core/components/CreditCard';
import Consult from './modules/Consult/pages/ConsultPage';
import ProposalsPage from './modules/Proposals/pages/ProposalsPage';
import PersornalInformationStep from './modules/Proposals/pages/steps/PersornalInformationStep';
import AddressInformationStep from './modules/Proposals/pages/steps/AddressInformationStep';

function App() {
  return (
    <>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/proposals/consult" element={<Consult />} />
        <Route path="/proposals" element={<ProposalsPage />}>
          <Route path="persornal-informations" element={<PersornalInformationStep />} />
          <Route path="address-informations" element={<AddressInformationStep />} />
          {/* <Route path="credit-cards" element={<CreditCardPage />} /> */}
        </Route>
      </Routes>
    </BrowserRouter>
    </>
  );
}

export default App;
