export default  [
    {
      id: '000',
      name: 'Sol',
      imageLink: require('./../../assets/images/sol.jpg'),
    },

    {
      id: '001',
      name: 'Mercúrio',
      imageLink: require('./../../assets/images/mercurio.jpg'),
      informacoesBasicas: {
        ordemOrbital: 1,
        distanciaDoSol: '0,46 UA',
        massa: '3,3011x(10)^23 kg',
        volume: '6,083x(10)^10 km³',
        densidade: '5,427 g/cm³',
        areaDaSuperficie: '7,48x(10)^7 km²',
        temperatura: '426°C a -183°C  ',
        periodoDeRotacao: '58,646 dias terrestres',
        periodoDeRevolucao: '115,88 dias terrestres',
        gravidade: '3,7 m/s²',
        velocidadeDeEscape: '4,25 km/s',
        satelites: 0,
      },
      curiosidades: [
        {
          id: '001',
          titulo: 'Temperatura,  tamanho, superfície e atmosfera.',
          historia: "\tMercúrio passou a ser o menor planeta do Sistema Solar em Agosto de 2006 devido ao rebaixamento de Plutão para planeta anão. Além de menor, Mercúrio também é o mais inferior planeta do Sistema Solar, entretanto apresenta a segunda maior temperatura entre os planetas , ficando abaixo de Vênus, o segundo planeta inferior. Ainda falando de suas condições térmicas, Mercúrio possui a maior variação de temperatura de todo o Sistema Solar chegando aos 600°C, isso acontece justamente pela falta de atmosfera no planeta, que dessemelhante a Terra não possui uma camada atmosférica para reter os raios ultravioletas direcionados pelo Sol, outra consquencia disso é o seu céu negro que difrente da Terra que possui o nitrogenio para difundir a luz azul, mercurio não possui nenhum desses gases." +
          "\n\tA falta de atmosfera do planeta, além de permitir a entrada dos fortes raios solares, também permite a entrada de meteoros que atingem o astro formando grandes crateras, a Terra por exemplo possui uma atmosfera que funciona como um escudo, diminuindo esses impactos por meio do atrito do ar em contato com objetivos que caem sobre ela. A Bacia de Caloris, a maior cratera do Sistema Solar(1.500km diâmetro) é uma das muitas crateras de Mercúrio e foi provocada pelo um grande impacto meteórico quase inteiramente de Ferro(96km diâmetro), afirma-se que após o impacto uma enorme onda sísmica convergiu até o ponto antípoda do impacto, ou seja, percorreu todo o planeta até o ponto oposto do impacto. Essa falta de atmosfera do planeta é responsabilizada pela sua baixa gravidade que se mostra quase incapaz de prender partículas atmosféricas à sua volta, o próprio movimento dessas partículas superam a velocidade de escape do próprio planeta deixando essas partículas vazarem para o espaço." +
          "\n\tÉ importante levantar o seguinte ponto sobre a atmosfera de Mercúrio, apesar de se dizer que o planeta Mercúrio não apresenta atmosfera, entre os anos 1960 e 1970 a sonda planetária Mariner 10, uma das únicas duas sondas enviadas para Mercúrio, conseguiu encontrar a presença de uma camada de hélio sobre o planeta. Isso gerou grande discussão no mundo científico levando a conclusão de que Mercúrio possui, sim, uma atmosfera, porém quase inexistente."
          
        },
        {
          id: '002',
          titulo: 'O misterioso interior do planeta.',
          historia: "O primeiro planeta do Sistema Solar e também o primeiro dos planetas inferiores ocupa a segunda colocação dos mais densos do sistema Solar, perdendo apenas para a nossa querida Terra. Levando em conta seu tamanho, o planeta apresenta cerca de 85% do seu volume em seu núcleo metálico(a terra por exemplo apresenta 20% do seu volume no núcleo), a qual se aponta ser fundido. Apelidada carinhosamente de bala de canhão, esta densa esfera metálica que orbita nosso Sol, nos dá pistas de um dos maiores impactos possíveis gerado nas redondezas de nosso Sistema Solar e que foram gerados logo após a “estabilidade” desta. A pequena se não inexistente atividade geológica do planeta devido a sua baixa gravidade faz com que nossa pequena vizinha seja chamada também planeta morto."
        },
      ]
    },

    {
      id: '002',
      name: 'Vênus',
      imageLink: require('./../../assets/images/venus.jpg'),
      informacoesBasicas: {
        ordemOrbital: 2,
        distanciaDoSol: '0,72 UA',
        massa: '4,8685x(10)^24 kg',
        volume: '9,2843x(10)^11 km³',
        densidade: '5,243 g/cm³',
        areaDaSuperficie: '4,60x(10)^8 km²',
        temperatura: '462°C',
        periodoDeRotacao: '243 dias terrestres',
        periodoDeRevolucao: '225 dias terrestres',
        gravidade: '8,87 m/s²',
        velocidadeDeEscape: '10,36 km/s',
        satelites: 0,
      },
      curiosidades: [
        {
          id: '001',
          titulo: 'Temperatura, semelhança com a Terra.',
          historia: "\tApesar de Vênus não ser o primeiro planeta mais próximo do Sol, sua temperatura chega a ser 36°C mais altas que o primeiro mais próximo. Devido a sua atmosfera rica em dióxido de carbono(CO2)(cerca de 96% de toda sua atmosfera) proveniente de seus vulcões, a atmosfera do planeta retém a saída de grande parte dos raios solares que nele chegam, o chamado efeito estufa que na Terra mantém a temperatura agradável de nosso planeta. Por esse efeito químico semelhante com a Terra, Vênus se tornou um grande modelo para estudos deste fenômeno que assola todo nosso globo, na verdade só descobrimos o efeito estufa por causa dele. Outros fatores físicos e químicos de Vênus deram ao astro o apelido de planeta irmão da Terra, por possuir semelhanças na composição, densidade, gravidade e volume."+ 
          "\n\tAlém disso, Vênus também é o planeta mais próximo da Terra, ficando apenas a 0,28 AU ou aproximadamente 4,2x(10)^7 km de distância. Em razão da sua proximidade, o não tão distante irmão da Terra pode ser visto a olho nu nos céus matutino e vespertino de nossa superfície devido a alta reflexividade de suas nuvens que refletem cerca de 80% de toda luz recebida pelo Sol. Sobre sua superfície, historiadores levantam hipóteses de que o planeta irmão da terra já possuiu uma atmosfera mais fria a qual permitiu a existência de oceanos e outras características semelhantes às da superfície terrestre."
        },
        {
          id: '002',
          titulo: 'Desastres naturais do planeta',
          historia: "\tO planeta Vênus é o único do Sistema Solar a qual gira em sentido retrógrado ou  sentido horário, dando a ele um nascer do Sol ao ocidente. Apesar de soar poético, isto aponta para a conclusão de que um forte impacto meteórico mudou o sentido da rotação do planeta. Uma catástrofe e tanto se não fosse levada em conta os vulcões do planeta que são responsáveis pela sua superfície ígnea e pelo aumento do efeito estufa pela liberação de CO2 e outros gases, esses são facilmente esquecidos quando observados a pouco mais de 48 km da superfície do planeta, onde choques elétricos alcançam temperaturas de até 28.000 graus centígrados por cada faísca de 1,0x(10)^8 de Volts(100 Milhões de Volts). Contudo essas violentas descargas elétricas nunca chegam a atingir o solo Venusiano devido a sua alta pressão atmosférica(90% maior que a pressão atmosférica da Terra, em virtude de sua alta densidade de gases atmosféricos, principalmente o dióxido de carbono do planeta), em vez disso essas poderosas descargas ficam presas sobre as nuvens do planeta, essas as quais são tóxicas o suficiente para queimar a pele humana. Com tudo isso é notório o quanto irônico o planeta é de seu nome, Vênus, deusa da beleza e do amor de nada se relaciona com o planeta caótico e violento que se é."
        },
      ]
    },

    {
      id: '003',
      name: 'Terra',
      imageLink: require('./../../assets/images/terra.jpg'),
      informacoesBasicas: {
        ordemOrbital: 3,
        distanciaDoSol: '1 UA',
        massa: '4,8685x(10)^24 kg',
        volume: '9,2843x(10)^11 km³',
        densidade: '5,243 g/cm³',
        areaDaSuperficie: '4,60x(10)^8 km²',
        temperatura: '462°C',
        periodoDeRotacao: '24 horas',
        periodoDeRevolucao: '365 dias',
        gravidade: '9,8 m/s²',
        velocidadeDeEscape: '10,36 km/s',
        satelites: 1,
      },
    },
  
    {
      id: '004',
      name: 'Marte',
      imageLink: require('./../../assets/images/marte.jpg'),
    },
    {
      id: '005',
      name: 'Júpiter',
      imageLink: require('./../../assets/images/jupiter.jpg'),
    },
    {
      id: '006',
      name: 'Saturno',
      imageLink: require('./../../assets/images/saturno.jpg'),
    },
    {
      id: '007',
      name: 'Urano',
      imageLink: require('./../../assets/images/urano.jpg'),
    },
    {
      id: '008',
      name: 'Netuno',
      imageLink: require('./../../assets/images/netuno.jpg'),
    },
    {
      id: '009',
      name: 'Plutão',
      imageLink: require('./../../assets/images/plutao.jpg'),
    },
    {
      id: '010',
      name: 'Sistema Solar',
      imageLink: require('./../../assets/images/sistemasolar.jpg'),
    },
  ]