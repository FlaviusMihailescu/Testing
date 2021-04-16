# Testing

In acest proiect a fost implementata o clasa care gestioneaza tranzactiile dintr-o banca si s-au testat diferitele 
functionalitati implementate, folosind urmatoarele metode:

am injectat datele: startBalance si detalii despre client

Stub = inlocuieste functionalitatea unei dependinta
	In cazul nostru inlocuieste functioinalitatea de conversie, prin intermediulul 
stub-ului injectam rata de schimb dorita de noi
Test Stub se ocupa cu indirect inputs

Test Spy se ocupa cu indirect output (e mult spus). Se uita la apeluri
indirect outuput = apeluri de metode

Test Spy = se uita daca SUT ul a apelat cum trebuie metodele sau oridnea
Logger ul aduga un mesaj si data la apelurile de metode

Dezavantaje TestSpy: daca se modifica un apel de metoda in cod, atunci trebuie sa
	se faca mentenanta si pentru toate testele

MockObject: exista o metoda Verify,
	pentru mock se seteaza niste asteptari pe care eu le am
	cele 4 asserturi de la Test Spy se inlocuiesccu  4 if-uri in interiorul metodei 
	Verify, unde o sa se  verifice daca nr de apeluri este cel asteptat(se returneaza
 	true/false)
	Nr de apeluri asteptat se seteaza in partea de set

MockFrameowrk = mock de destare automata
	noi ii dam interfata si ii spunem cum sa implementeze codul pentru noi
	Functionalitate:
		new Mock<interfarta>  
			in spate Framework ul de Mocking va crea un obiect care implementeaza 
			interfata
			i se spune obiect de tip Mock



