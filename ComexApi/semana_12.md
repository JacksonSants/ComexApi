## Microsserviços

## 🌐Funcionamentro da web
O funcionamento da web ocorre pelo modelo cliente/servidor. Neste modelo a comunicação ocorre por meio de um protócolo tcp
onde o cliente manda requisições através da web por meio do protócolo http para um servido, o servidor processasa as requisições
e devolve uma resposta para o cliente, renderizando assim as informações para client e (página web).

## ⚙️Arquitetura de Microsserviços.
Cada funcionalidades/processo dentro do sistema possui funcionalidades diferente (serviço) com uma responsabilidade bem 
definida. Assim, da mesma forma o armazenamento de dados dos microsserviços são armazenados em banco de dados diferente, 
ouseja cada serviços possui seu próprio banco de dados.
Microsserviços

Microsserviços são uma abordagem arquitetônica e organizacional do desenvolvimento de software na qual o sofware consiste 
e pequenos serviços independentes que se comunicam usando APIs bem definidades. Esses serviços pertencem a pequenas equipes
autosuficientes.
Vantagens

    • Projetos independente
    • Falha em 1 serviços é isolada
    • Deploy menores e ais rápido
Vantagens

    • Maior complexidade de desenvolvimento
    • Debug mais complexo
    • Comunicação entre serviços devem ser bem definida
    • Diversas tecnologias pode ser um problema
    • Monitoramento é crucial e mais complexo

Tipos de serviços

    • Data service
	Serviço de dados. Um data service é um tipo de serviço que simplesmente expõe dados, funcionando como uma camada 
    fina entre os usuários e o banco de dados. Sua 	unção principal é receber dados e realizar o processamento necessário 
    para manter a  consistência desses dados.
    • Business service
	Serviço de negócio. é um tipo de serviço que, além de consumir dados de alguma 	orma, seja consumindo um data service 
    ou tendo ele acesso direto a um banco de dados, ele fornece operações mais complexas.
    • Translation service
	Formas e controle de serviços. Basicamente, uma forma de acessar algum recurso externo, mas mantendo certo controle.
    • Edge service
	Serviço de ponta. Um edge service, como o nome já diz, é algo que é entregue diretamente para o cliente e pode ter 
    necessidades específicas.
