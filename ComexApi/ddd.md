6 -  Explique o conceito de Bounded Context (Contexto Delimitado) e como ele pode ser usado para organizar sistemas complexos. 

    Por outro lado, os Contextos Delimitados situam-se no espaço da solução e são uma resposta arquitetural à complexidade encontrada nos subdomínios. Eles definem fronteiras claras dentro das quais um modelo de domínio específico é válido. Esta separação permite que diferentes modelos convivam sem interferência, cada um adaptado às particularidades de sua área, refletindo uma compreensão profunda das necessidades do negócio e das limitações técnicas.
    
    A relação entre Contextos Delimitados e modelos de domínio é intrínseca. Um Contexto Delimitado encapsula um modelo de domínio, que é a representação abstrata e simplificada dos conceitos, relações e regras de negócio específicas daquele contexto. Essa encapsulação favorece a modularidade e a independência, permitindo que cada equipe de desenvolvimento se concentre em resolver os problemas de seu respectivo subdomínio com uma linguagem e perspectiva coesas, conhecida como Linguagem Ubíqua. Este alinhamento entre os contextos delimitados (espaço da solução) e os subdomínios (espaço do problema) é crucial para a criação de sistemas complexos que são ao mesmo tempo robustos, flexíveis e alinhados com os objetivos de negócio.

 7 - Quais são as principais responsabilidades de um repositório (Repository) em DDD?
    
    Um Repository em DDD é uma interface que nos permite interagir com agregados, unidades de regras de negócio e dados que devem ser tratados juntos. É um padrão de design que separa a lógica de negócios da persistência de dados. Essa separação promove um código limpo e facilita manutenções e evoluções do sistema.

8 -  Quando é apropriado usar um serviço de domínio em vez de encapsular a lógica dentro de uma entidade ou objeto de valor?  

    É apropriado usar um serviço de domínio em vez de encapsular a lógica dentro de uma entidade ou objeto de valor quando a regra de negócio não pode ser determinada a uma entidade específica.

9 -  Explique a diferença entre a camada de domínio e a camada de aplicação em uma arquitetura baseada em DDD.

    Em uma arquitetura baseada em Domain-Driven Design (DDD), a camada de domínio e a camada de aplicação desempenham papéis distintos, porém, interdependentes. 
    
    Camada de Domínio
    Em uma arquitetura baseada em Domain-Driven Design (DDD), a camada de domínio e a camada de aplicação desempenham papéis distintos, mas interdependentes. Compreender essa distinção é fundamental para construir sistemas robustos, escaláveis e alinhados com os requisitos de negócio.
    
    Camada de Domínio
    A camada de domínio representa o núcleo do sistema, encapsulando as regras de negócio, entidades, agregados e valores que definem o problema do domínio.
    Regras de Negócio: Contém a lógica de negócio específica do domínio, como validações, cálculos e fluxos de trabalho.
    Entidades: Objetos do mundo real com um ciclo de vida e identidade.
    Agregados: Grupos de entidades relacionadas que são tratadas como uma única unidade.
    Valores: Objetos imutáveis que representam atributos de entidades ou agregados.
    Repositórios: Fornecem um mecanismo para persistir e recuperar agregados.
    
    Camada de Aplicação
    A camada de aplicação serve como um orquestrador, coordenando as operações do sistema.
    Casos de Uso: Implementa os casos de uso, que representam as interações do usuário com o sistema.
    Coordenação: Recebe as entradas do usuário, valida os dados e delega a execução das tarefas para a camada de domínio.
    Sem Regras de Negócio: Não contém regras de negócio específicas do domínio, apenas a lógica para coordenar a execução dos casos de uso.

10 -  Quais são os principais desafios ao adotar o DDD em um projeto de software?

    Complexidade do modelo de domínio : A modelagem do domínio pode ser complexa e desafiadora, especialmente para negócios complexos. À medida que o modelo de domínio cresce, pode se tornar difícil manter a coesão e evitar a duplicação de código.
    
    Falta de colaboração entre equipes : A falta de colaboração entre as equipes pode levar a um modelo de domínio impreciso ou incompreensível. É importante estabelecer uma comunicação clara e aberta entre as equipes de desenvolvimento e de negócios para garantir que todos estejam alinhados com as expectativas.
    
    Resistência à mudança : A implementação do Domain-driven Design pode exigir uma mudança cultural significativa nas equipes de desenvolvimento. É importante que todos os envolvidos no projeto estejam dispostos a adotar a nova abordagem e trabalhar juntos para garantir o sucesso.
